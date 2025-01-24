
using CSP.Application.Requests.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UtilityServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Handles HLR Check API Call via MediatR.
        /// </summary>
        /// <param name="request">HLR Check Request</param>
        /// <returns>HLR Check Response</returns>
        [HttpPost("HLRcheck")]
        public async Task<IActionResult> HLRCheck([FromBody] HLRCheckRequest request)
        {
            if (request == null || request.Number==0 || string.IsNullOrEmpty(request.Type))
            {
                return BadRequest("Invalid request. Ensure 'number' and 'type' are provided.");
            }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Information about DTH
        /// </summary>
        /// <param name="request">DTH Request</param>
        /// <returns>DTHInfo Response</returns>
        [HttpPost("DTHInfo")]
        public async Task<IActionResult> DTHInfo([FromBody] DTHInfoRequest request)
        {
            if (request == null || request.Canumber == 0 || string.IsNullOrEmpty(request.OP))
            {
                return BadRequest("Invalid request. Ensure 'CAnnumber' and 'op' are provided.");
            }

            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
