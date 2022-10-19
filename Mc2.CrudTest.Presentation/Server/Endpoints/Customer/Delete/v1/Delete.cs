using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Delete.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class Delete : ControllerBase
    {
        private readonly ISender _mediator;
        public Delete(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("customer/{id}")]
        [SwaggerOperation(
            Summary = "Delete a Customer",
            Description = "Delete a Customer",
            OperationId = "Customer.Delete",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public async Task<IActionResult> Handler([FromRoute]int id)
        {
            var result = await _mediator.Send(new Core.Query.Customer.Delete(id));
            return result ? Ok() : BadRequest();
        }
    }
}
