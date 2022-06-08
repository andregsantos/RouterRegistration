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

                routersList = _unitOfWork.GetConnection.Query<Route>("Select * from [Route]", commandType: CommandType.Text)
                    .ToList();

                return routersList;
            }
            catch
            {
                throw;
            }
        }

        public void NewRoute(Route route)
        {
            _unitOfWork.GetConnection.Execute("Insert into [Route] ([from],[to],[price]) values(@from,@to,@price)", route);
        }

        public void DeleteRoute(int id)
        {
            _unitOfWork.GetConnection.Execute("Delete from [Route] where Id=@Id", new
            {
                @Id = id
            });
        }

        public void UpdateRoute(Route route)
        {
            _unitOfWork.GetConnection.Execute("Update Route set [from]=@from,[to]=@to,price=@price where Id=@Id", route);
        }
    }
}
