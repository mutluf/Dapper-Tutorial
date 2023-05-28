using AutoMapper;
using Dapper.Domain.Models;
using Dapper.FluentMap.Dommel.Mapping;
using DapperT.Application.Abstractions;
using MediatR;

namespace DapperT.Application.Features.Commands
{
    public class CreateCustomerRequest:IRequest<CreateCustomerResponse>
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

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCustomerHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customer =  _mapper.Map<Customer>(request);

            string sqlCommand = "SP_CreateNewCustomer";
            await _unitOfWork.Customers.AddAsync(customer,sqlCommand);

            return new()
            {
                Message = "eklendi"
            };
        }
    }

    public class CreateCustomerResponse
    {
        public string Message { get; set; }
    }
}
