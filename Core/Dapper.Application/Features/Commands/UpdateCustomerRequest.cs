using AutoMapper;
using Dapper.Domain.Models;
using DapperT.Application.Abstractions;
using MediatR;

namespace DapperT.Application.Features.Commands
{
    public class UpdateCustomerRequest:IRequest<UpdateCustomerResponse>
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }

    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(request);
          

            string sqlCommand = "SP_UpdateCustomer";
            await _unitOfWork.Customers.Update(customer,sqlCommand);

            return new()
            {
                Message = "güncellendi"
            };
        }
    }

    public class UpdateCustomerResponse
    {
        public string Message { get; set; }
    }
}
