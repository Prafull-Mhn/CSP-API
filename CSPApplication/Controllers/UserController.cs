using CSP.Application.Users.Commands;
using CSP.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetUserById(int id)
            {
                var result = await _mediator.Send(new GetUserByIdQuery(id));
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetUserById), new { id = result }, null);
            }
        }



        //[HttpPost]
        //public async Task<IActionResult> CreateUser(CreateUserCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return CreatedAtAction(nameof(GetUser), new { id = result }, null);
        //}

        //[HttpGet("getUserDetails/{userid}")]
        //public async Task<IActionResult> GetUser(int userId)
        //{

        //    try
        //    {
        //        var user = await _mediator.Send(new GetUserQuery { UserId = id });
        //        return user == null ? NotFound() : Ok(user);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return StatusCode(500,Ex.Message.ToString());
        //    }

        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, UpdateUserCommand command)
        //{
        //    if (id != command.UserId)
        //        return BadRequest("User ID mismatch.");

        //    await _mediator.Send(command);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    await _mediator.Send(new DeleteUserCommand { UserId = id });
        //    return NoContent();
        //}
    }

