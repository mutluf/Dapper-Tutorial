using DapperT.Application.Abstractions;
using DapperT.Domain.Entities;
using MediatR;

namespace DapperT.Application.Features.Queries
{
    public class GetCategoriesRequest:IRequest<GetCategoriesResponse>
    {
    }

    public class GetCategoriesHandle : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriesHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = _unitOfWork.Categories.GetAllAsync();

            return new()
            {
                Categories = categories
            };
        }
    }

    public class GetCategoriesResponse
    {
        public Task<IReadOnlyList<Category>> Categories { get; set; }
    }
}
