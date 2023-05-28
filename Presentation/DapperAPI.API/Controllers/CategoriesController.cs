using DapperT.Application.Features.Commands;
using DapperT.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetCategoriesRequest request = new GetCategoriesRequest();
            GetCategoriesResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            CreateCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{CategoryID}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdRequest request)
        {
            GetCategoryByIdResponse response= await _mediator.Send(request);

            return Ok(response);
        }
    }
}
