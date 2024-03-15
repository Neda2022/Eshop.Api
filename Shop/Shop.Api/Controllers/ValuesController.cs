using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Query.Categories.GetById;
using Shop.Query.Orders.GetById;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
          var result=await  _mediator.Send(new GetOrderByIdQuery(1)); 
            return Ok(result);
        }
    }
}
