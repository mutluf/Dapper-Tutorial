using Dapper.Domain.Models;
using DapperT.Application.Abstractions;
using DapperT.Persistence.Repositories;
using Dommel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {
        }

    }
}
