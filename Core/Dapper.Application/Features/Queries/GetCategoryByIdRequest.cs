using Dapper.Domain.Models;
using DapperT.Application.Abstractions;
using DapperT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperT.Application.Features.Queries
{
    public class GetCategoryByIdRequest:IRequest<GetCategoryByIdResponse>
    {
        public int CategoryID { get; set; }
    }

    public class GetCategoryByIdHandle : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {

            string sqlQuery = "SP_GetCategoryById";
            int categoryId=request.CategoryID;

            Category category = await _unitOfWork.Categories.GetByIdAsync(categoryId,sqlQuery:sqlQuery);

            return new()
            {
                Category = category,
            };
        }
    }

    public class GetCategoryByIdResponse
    {
        public Category Category { get; set; }
    }


}
