using DapperT.Application.Abstractions;
using DapperT.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace DapperT.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IConfiguration config) : base(config)
        {
        }
    }
}
