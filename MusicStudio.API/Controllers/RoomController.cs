using Microsoft.AspNetCore.Mvc;

namespace MusicStudio.API.Controllers
{
    [ApiController]
    [Route("api/Rooms")]
    public class RoomController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
