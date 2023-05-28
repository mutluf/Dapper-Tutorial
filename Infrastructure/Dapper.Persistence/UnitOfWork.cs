using DapperT.Application.Abstractions;
using System.Data;

namespace DapperT.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        public ICustomerRepository Customers { get; }
        public ICategoryRepository Categories { get; }


        public UnitOfWork(ICustomerRepository customerRepository, ICategoryRepository categories)
        {
            Customers = customerRepository;
            Categories = categories;
        }
        public UnitOfWork( IDbConnection connection, IDbTransaction transaction)
        {         
            _connection = connection;
            _transaction = transaction;
        }

       
        public IDbConnection Connection => _connection;


        public void Commit()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }

        public void Dispose()
        {
            if (_disposed) return;

            _transaction.Dispose();
            _connection.Close();
            _connection.Dispose();

            _disposed = true;
        }
    }
}
