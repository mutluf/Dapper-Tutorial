using Dapper;
using DapperT.Application.Abstractions;
using Dommel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperT.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly IConfiguration _config;

        public GenericRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task AddAsync(T entity, string sqlCommand)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("MicrosoftSQL"));
            if (sqlCommand != "")
            {
                await connection.QueryAsync<T>(sqlCommand, entity, commandType: CommandType.StoredProcedure);
            }
            else
            {
                connection.Insert<T>(entity);
            }
        }

        public async Task DeleteAsync(T model)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("MicrosoftSQL"));
            connection.Delete<T>(model);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(string sqlQuery)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("MicrosoftSQL"));

            if (sqlQuery != "")
            {
                IEnumerable<T> datas = await connection.QueryAsync<T>(sqlQuery, commandType: CommandType.StoredProcedure);
                return datas.ToList();
            }
            else
            {
                var datas = connection.GetAll<T>().ToList();
                return datas;
            }
        }


        public async Task<T> GetByIdAsync(int Id, string sqlQuery)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("MicrosoftSQL"));
        
            var entity = await connection.QueryFirstAsync<T>(sqlQuery, new { Id = Id }, commandType: CommandType.StoredProcedure);

            return entity;         
        }

        public async Task Update(T entity, string sqlCommand)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("MicrosoftSQL"));
            var data = await connection.QueryAsync<T>(sqlCommand, entity, commandType: CommandType.StoredProcedure);
        }
    }
}
