using RouterRegistration.Core.Model;
using System.Collections.Generic;

namespace RouterRegistration.Core.Service
{
    /// <summary>
    /// The IRouterService Inteface describes the implementation required for Routers
    /// </summary>
    public interface IRouteService
    {
        IEnumerable<Route> GetAllRoutes();
        RouteSearch SearchRoute(string from, string to);
        void NewRoute(Route route);
        void DeleteRoute(int routeId);
        void UpdateRoute(Route route);    }
}
