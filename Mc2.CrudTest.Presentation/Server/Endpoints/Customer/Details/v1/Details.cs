using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Details.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class Details : ControllerBase
    {
        private readonly ISender _mediator;
        public Details(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customer")]
        [SwaggerOperation(
            Summary = "Gets a Customer by Id",
            Description = "Gets a Customer by Id",
            OperationId = "Customer.Details",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public async Task<IActionResult> Handler(int id)
        {
            var result = await _mediator.Send(new Core.Query.Customer.GetById(id));
            return Ok(result);
        }
    }
}
