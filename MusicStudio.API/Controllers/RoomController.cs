using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStudio.Application.Commands.CreateRoomCommand;
using MusicStudio.Application.Commands.CreateTimeCommand;
using MusicStudio.Application.Commands.CreateUserCommand;
using MusicStudio.Application.Commands.DeleteUserCommand;
using MusicStudio.Application.Commands.UpdateTimeCommand;
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

            var rooms = await _mediator.Send(Query);

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var query = new GetUserQuery(id);

            var room = await _mediator.Send(query);

            if (!room.IsSuccess)
            {
                return BadRequest(room.Message);
            }

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomCommand command)
        {
            var RoomId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetRoomById), new { id = RoomId }, command);
        }
        [HttpPost]
        [Route("Scheduling")]
        public async Task<IActionResult> CreateTime(CreateTimeCommand command)
        {
            var TimeId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetRoomById), new { id = TimeId }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTime(UpdateTimeCommand command)
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
