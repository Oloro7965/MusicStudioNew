using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStudio.Application.Commands.CreateScheduleCommand;
using MusicStudio.Application.Commands.CreateUserCommand;
using MusicStudio.Application.Commands.DeleteSchedulingCommand;
using MusicStudio.Application.Commands.DeleteUserCommand;
using MusicStudio.Application.Queries.GetAllSchedulingByUserIdQuery;
using MusicStudio.Application.Queries.GetAllSchedulingQuery;
using MusicStudio.Application.Queries.GetAllUsersQuery;
using MusicStudio.Application.Queries.GetSchedulingById;
using MusicStudio.Application.Queries.GetUserQuery;

namespace MusicStudio.API.Controllers
{
    [ApiController]
    [Route("Api")]
    public class SchedulingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchedulingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSchedulings()
        {

            var Query = new GetAllSchedulingQuery();

            var contacts = await _mediator.Send(Query);

            return Ok(contacts);
        }
        [HttpGet("user/{id}/schedulings")]
        public async Task<IActionResult> GetAllSchedulingByUserId(Guid id)
        {

            var Query = new GetAllSchedulingByUserIdQuery(id);

            var contacts = await _mediator.Send(Query);

            return Ok(contacts);
        }
        [HttpGet("scheduling/{id}")]
        public async Task<IActionResult> GetSchedulingById(Guid id)
        {
            var query = new GetSchedulingByIdQuery(id);

            var contact = await _mediator.Send(query);

            if (!contact.IsSuccess)
            {
                return BadRequest(contact.Message);
            }

            return Ok(contact);
        }
        [HttpPost]
        public async Task<IActionResult> CreateScheduling( CreateScheduleCommand command)
        {
            var ContactId = await _mediator.Send(command);

            //return CreatedAtAction(nameof(GetSchedulingById), new { id = ContactId }, command);
            return Ok();
        }

        // GET: SchedulingController/Delete/5
        [HttpDelete]
        public async Task<ActionResult> DeleteScheduling(Guid id)
        {
            var command = new DeleteSchedulingCommand(id);

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
