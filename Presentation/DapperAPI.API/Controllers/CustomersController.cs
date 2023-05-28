using DapperT.Application.Features.Commands;
using DapperT.Application.Features.Queries;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
       private readonly IMediator _mediator;
        private readonly IBusControl _bus;

        public CustomersController(IMediator mediator, IBusControl bus)
        {
            _mediator = mediator;
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetCustomerRequest request= new GetCustomerRequest();
            GetCustomerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerRequest request)
        {
            CreateCustomerResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {         
            UpdateCustomerResponse response = await _mediator.Send(request);
            return Ok(response);    
        }

        [HttpDelete("{CustomerId}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] DeleteCustomerRequest request)
        {
            //var command = new DeleteCustomerCommand { CustomerId = customerId };
            await _mediator.Send(request);
            

            return Ok();
        }
    }
}
