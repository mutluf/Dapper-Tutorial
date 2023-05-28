using AutoMapper;
using Dapper.Domain.Models;
using DapperT.Application.Features.Commands;
using DapperT.Domain.Entities;

namespace DapperT.Application.GeneralMap
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateCustomerRequest, Customer>().ReverseMap();
            CreateMap<UpdateCustomerRequest, Customer>().ReverseMap();
            CreateMap<CreateCategoryRequest,Category>().ReverseMap();
            CreateMap<DeleteCustomerRequest,Customer>().ReverseMap();
        }
    }
}
