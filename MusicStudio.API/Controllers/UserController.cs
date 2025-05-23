using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStudio.Application.Commands.CreateScheduleCommand;
using MusicStudio.Application.Commands.CreateUserCommand;
using MusicStudio.Application.Commands.DeleteUserCommand;
using MusicStudio.Application.Commands.UpdateUserCommand;
using MusicStudio.Application.Queries.GetAllSchedulingQuery;
using MusicStudio.Application.Queries.GetAllUsersQuery;
using MusicStudio.Application.Queries.GetUserQuery;

namespace MusicStudio.API.Controllers
{
    [ApiController]
    [Route("Api/Users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {

            var Query = new GetAllUsersQuery();

            var users = await _mediator.Send(Query);

            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (!user.IsSuccess)
            {
                return BadRequest(user.Message);
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var UserId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = UserId }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsert(UpdateUserCommand command)
        {
            //command.Id =id;

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(id);

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            //_userService.Delete(id);
            return Ok();
        }
    }
}
