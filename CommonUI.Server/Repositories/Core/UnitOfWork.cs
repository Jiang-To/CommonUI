using System;
using System.Data;
using System.Data.SqlClient;

namespace CommonUI.Server.Repositories {

    public abstract class UnitOfWork : IUnitOfWork, IDisposable {

        protected readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(string connectionString) {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public void BeginTransaction() {
            _transaction = _connection.BeginTransaction();
        }

        public void CommitTransaction() {
            try {
                _transaction.Commit();
            }
            catch {
                _transaction.Rollback();
                throw;
            } finally {
                _transaction.Dispose();
            }
        }

        public void Dispose() {
            
        }
    }

}