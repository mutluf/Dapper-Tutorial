namespace DapperT.Application.Abstractions
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        ICategoryRepository Categories { get; }
    }
}
