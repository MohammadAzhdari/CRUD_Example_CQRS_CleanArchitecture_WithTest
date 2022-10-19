using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Endpoints.Customer.Add.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class Add : ControllerBase
    {
        private readonly ISender _mediator;
        public Add(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("customer")]
        [SwaggerOperation(
            Summary = "Add a Customer",
            Description = "Add a Customer",
            OperationId = "Customer.Add",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public async Task<IActionResult> Handler([FromBody]Core.Entities.Customer request)
        {
            var result = await _mediator.Send(new Core.Query.Customer.Add(request));
            return result != null ? Created("", result.Id) : BadRequest();
        }
    }
}
