using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly ISpaceService _spaceService;

        public SpaceController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Space>> GetAllSpace()
        {
            return _spaceService.GetAllSpaces();
        }

        [HttpGet("{id}")]
        public ActionResult<Space> GetSpaceById(int id)
        {
            return _spaceService.GetSpaceById(id);
        }
        [HttpGet("{id}/events")]
        public ActionResult<IEnumerable<Event>> GetEventsBySpaceId(int id)
        {
            return _spaceService.GetEventsOfASpace(id);
        }




    }
}
