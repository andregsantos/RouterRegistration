using Dapper;
using RouterRegistration.Core.Model;
using RouterRegistration.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RouterRegistration.Repository
{
    public class RouterRepository : Repository,
        IRouterRepository
    {
        public RouterRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public IEnumerable<Router> GetAllRouters()
        {
            try
            {
                List<Router> routersList = new List<Router>();

                routersList = Connection.Query<Router>("Select * from Routers", commandType: CommandType.Text)
                    .ToList<Router>();

                return routersList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
