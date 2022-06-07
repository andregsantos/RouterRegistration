using Dapper;
using RouterRegistration.Core.Model;
using RouterRegistration.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RouterRegistration.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RouteRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Route> GetAllRouters()
        {
            try
            {
                List<Route> routersList = new List<Route>();

                routersList = _unitOfWork.GetConnection.Query<Route>("Select * from Router", commandType: CommandType.Text)
                    .ToList();

                return routersList;
            }
            catch
            {
                throw;
            }
        }
    }
}
