using CSP.Application.Services.Command;
using CSP.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("HLRCheck")]
        public async Task<IActionResult> CheckHLRUser([FromBody] HLRCheckCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result); //CreatedAtAction(nameof(HLRList), new { id = result }, null);
        }
    }
}
