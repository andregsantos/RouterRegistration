using System;

namespace RouterRegistration.Core.Repository
{
    /// <summary>
    /// Its decribes the unit of work that will help to mantain consitency.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRouterRepository RouterRepository { get; }

        void BeginTransaction();
        void CommitTransaction();
    }
}
