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

        public IRouteRepository RouterRepository { get; private set; }

        public UnitOfWork(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));

            RouterRepository = new RouteRepository(this);
        }

        public IDbConnection GetConnection => _connection;

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
