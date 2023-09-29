using AnyCompany.Infrastructure.Interfaces.UnitOfWork;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public UnitOfWork()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AnyCompanyOrdersConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        //commit the transaction and rollback if there is an error
        public void Commit()
        {
            try { _transaction.Commit(); }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }

        }


        public IDbTransaction GetTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _connection.BeginTransaction();
            }
            return _transaction;
        }

        public IDbConnection GetConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
