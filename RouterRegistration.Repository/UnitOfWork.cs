using Microsoft.Extensions.Configuration;
using RouterRegistration.Core.Repository;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RouterRegistration.Repository
{
    /// <summary>
    /// UnitOfWork implemented IUnitOfWork to maintain the consistency in data source
    /// </summary>

    /// <summary>
    /// UnitOfWork implemented IUnitOfWork to maintain the consistency in data source
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public IRouterRepository RouterRepository { get; private set; }

        public UnitOfWork(IConfiguration config)
        {
            string connString = config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connString);

            RouterRepository = new RouterRepository(_connection);
        }

        public void BeginTransaction()
        {
            try
            {
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }
                throw;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Commit();

                }
            }
            catch (Exception)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }
                throw;
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _connection.Dispose();
        }
    }
}
