using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.List.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class List : Controller
    {
        private readonly ISender _mediator;
        public List(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customers")]
        [SwaggerOperation(
            Summary = "Gets a list of all Customers",
            Description = "Gets a list of all Customers",
            OperationId = "Customer.List",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public async Task<IActionResult> Handler()
        {
            var result = await _mediator.Send(new Core.Query.Customer.GetAll());
            return Ok(result);
        }
    }
}
