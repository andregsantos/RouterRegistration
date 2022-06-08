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
            var hashSetOfRoute = new HashSet<string>();

            var routes = _unitOfWork.RouterRepository.GetAllRouters()
                .ToList();

            routes.ForEach((r) =>
            {
                hashSetOfRoute.Add(r.To);
                hashSetOfRoute.Add(r.From);
            });

            var nodes = new Dictionary<string, Node>();

            hashSetOfRoute.ToList().ForEach((r) => nodes.Add(r, new Node(r)));

            routes.ForEach((r) => nodes[r.To].ConnectTo(nodes[r.From], r.Price));

            try
            {
                var shortestPathTest = _shortestPathFinder.FindShortestPath(nodes[from], nodes[to]);

                var routesList = new List<string>();
                shortestPathTest.ToList().ForEach(r => routesList.Add(r.Label));

                int price = 0;

                //calcula valores
                for (int i = 0; i < routesList.Count() - 1; i++)
                {
                    price += routes.FirstOrDefault(x => (x.From == routesList[i] && x.To == routesList[i + 1]) ||
                       (x.To == routesList[i] && x.From == routesList[i + 1])).Price;
                }

                return new RouteSearch() { Routes = routesList, Price = price };

            }
            catch
            {
                throw new System.ApplicationException("Invalid route.");
            }
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return _unitOfWork.RouterRepository.GetAllRouters();
        }

        public void NewRoute(Route route)
        {
            _unitOfWork.RouterRepository.GetAllRouters();
        }

        public void DeleteRoute(int routeId)
        {
            _unitOfWork.RouterRepository.GetAllRouters();
        }

        public void UpdateRoute(Route route)
        {
            _unitOfWork.RouterRepository.GetAllRouters();
        }
    }
}