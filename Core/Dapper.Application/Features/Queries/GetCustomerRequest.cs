using Dapper.Domain.Models;
using DapperT.Application.Abstractions;
using MediatR;

namespace DapperT.Application.Features.Queries
{
    public class GetCustomerRequest:IRequest<GetCustomerResponse>
    {
    }

    public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {    
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            string sqlQuery = "sp_GetCustomers";
            var customers = await _unitOfWork.Customers.GetAllAsync(sqlQuery);

            return new()
            {
                Customers = customers,
            };
        }
    }

    public class GetCustomerResponse
    {
        public IReadOnlyList<Customer> Customers { get; set;}
    }
}
