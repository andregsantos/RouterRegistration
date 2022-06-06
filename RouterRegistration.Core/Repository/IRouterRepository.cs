using RouterRegistration.Core.Model;
using System.Collections.Generic;

namespace RouterRegistration.Core.Repository
{
    public interface IRouterRepository
    {
        IEnumerable<Router> GetAllRouters();
    }
}
