using AutoMapper;
using DapperT.Application.Abstractions;
using DapperT.Domain.Entities;
using MediatR;
using System.Text;

namespace DapperT.Application.Features.Commands
{
    public class CreateCategoryRequest:IRequest<CreateCategoryResponse>
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryHandle : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandle(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
        
            await _unitOfWork.Categories.AddAsync(category);

            return new()
            {
                Message = "Başarıyla eklendi"
            };
        }
    }

    public class CreateCategoryResponse
    {
        public string Message { get; set; }
    }
}
