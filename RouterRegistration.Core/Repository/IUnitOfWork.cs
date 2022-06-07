using System;
using System.Data;

namespace RouterRegistration.Core.Repository
{
    /// <summary>
    /// Its decribes the unit of work that will help to mantain consitency.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection GetConnection { get;}
        IRouteRepository RouterRepository { get; }

        void BeginTransaction();
        void CommitTransaction();
    }
}
