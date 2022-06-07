using RouterRegistration.Core.Model;
using System.Collections.Generic;

namespace RouterRegistration.Core.Repository
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetAllRouters();
    }
}
