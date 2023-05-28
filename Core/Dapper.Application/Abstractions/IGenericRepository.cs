namespace DapperT.Application.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id=0, string sqlQuery="");
        Task<IReadOnlyList<T>> GetAllAsync(string sqlQuery="");
        Task AddAsync(T entity, string sqlCommand="");
        Task Update(T entity, string sqlCommand = "");
        Task DeleteAsync(T model);
    }
}
