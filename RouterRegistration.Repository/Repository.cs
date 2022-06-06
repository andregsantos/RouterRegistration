using System.Data;

namespace RouterRegistration.Repository
{
    public class Repository
    {
        protected readonly IDbConnection Connection;

        public Repository(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
