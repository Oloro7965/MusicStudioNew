using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStudio.Application.Commands.CreateUserCommand;
using MusicStudio.Application.Commands.DeleteUserCommand;
using MusicStudio.Application.Commands.UpdateUserCommand;
using MusicStudio.Application.Queries.GetAllUsersQuery;
using MusicStudio.Application.Queries.GetUserQuery;

namespace MusicStudio.API.Controllers
{
    [ApiController]
    [Route("api/Rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {

            var Query = new GetAllUsersQuery();

            var contacts = await _mediator.Send(Query);

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var query = new GetUserQuery(id);

            var contact = await _mediator.Send(query);

            if (!contact.IsSuccess)
            {
                return BadRequest(contact.Message);
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateUserCommand command)
        {
            var ContactId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetRoomById), new { id = ContactId }, command);
        }
        [HttpPost]
        [Route("Scheduling")]
        public async Task<IActionResult> CreateTime(CreateUserCommand command)
        {
            var ContactId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetRoomById), new { id = ContactId }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTime(UpdateUserCommand command)
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
        public async Task<IActionResult> DeleteTime(Guid id)
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
