using RouterRegistration.Core.Model;
using System.Collections.Generic;

namespace RouterRegistration.Core.Repository
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetAllRouters();
        void NewRoute(Route route);
        void DeleteRoute(int id);
        void UpdateRoute(Route route);
    }
}
