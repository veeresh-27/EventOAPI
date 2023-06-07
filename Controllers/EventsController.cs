using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet("all")]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            return _eventService.GetAllEvents();
        }
        [HttpPost("create")]
        public ActionResult<Event> CreateEvent(EventDto dto)
        {
            return _eventService.AddEvent(dto);
        }

    }
}
