using RouterRegistration.Core.Grafo;
using RouterRegistration.Core.Grafo.IFace;
using RouterRegistration.Core.Model;
using RouterRegistration.Core.Repository;
using RouterRegistration.Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace RouterRegistration.Services
{
    public class RouteService : IRouteService
    {
        /// <summary>
        /// Private IUnitOfWork Data Member
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShortestPathFinder _shortestPathFinder;

        /// <summary>
        /// NewsService Constructor
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public RouteService(IUnitOfWork unitOfWork, IShortestPathFinder shortestPathFinder)
        {
            _unitOfWork = unitOfWork;
            _shortestPathFinder = shortestPathFinder;
        }

        public RouteSearch SearchRoute(string from, string to)
        {
            var lista = new HashSet<string>();

            var routes = _unitOfWork.RouterRepository.GetAllRouters()
                .ToList();

            for (int i = 0; i < routes.Count; i++)
            {
                var r = routes[i];
                lista.Add(r.To);
                lista.Add(r.From);
            }

            var nodes = new Dictionary<string, Node>();
            foreach (var item in lista)
            {
                nodes.Add(item, new Node(item));
            }

            for (int i = 0; i < routes.Count; i++)
            {
                var r = routes[i];
                nodes[r.To].ConnectTo(nodes[r.From], r.Price);
            }

            var shortestPathTest = _shortestPathFinder.FindShortestPath(nodes[from], nodes[to]);
            List<string> retorno = new List<string>();
            foreach (var item in shortestPathTest)
            {

                retorno.Add(item.Label);
            }

            int price = 0;
            //calcula valores
            for (int i = 0; i < retorno.Count() - 1; i++)
            {
                 price += routes.FirstOrDefault(x => (x.From == retorno[i] && x.To == retorno[i + 1]) ||
                    (x.To == retorno[i] && x.From == retorno[i + 1])).Price;
            }

            return new RouteSearch() { Routes = retorno, Price = price };
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return _unitOfWork.RouterRepository.GetAllRouters();
        }
    }
}