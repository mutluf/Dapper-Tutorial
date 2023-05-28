using Dapper.Domain.Models;
using DapperT.Application.Abstractions;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperT.Application.Features.Commands
{
    public class DeleteCustomerRequest:IRequest<CustomerDeleteResponse>
    {
        public string CustomerId { get; set; }
    }

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, CustomerDeleteResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<CustomerDeleteResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {

            Customer customer = await _unitOfWork.Customers.GetByIdAsync(int.Parse(request.CustomerId));
            await _unitOfWork.Customers.DeleteAsync(customer);

        
            return new()
            {
                Message = "başarıyla silindi"
            };
        }
    }

    public class CustomerDeleteResponse
    {
        public string Message { get; set; }
        
    }
}
