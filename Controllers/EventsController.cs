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
        [HttpGet("{eventId}")]
        public ActionResult<Event> GetEventById(int eventId)
        {
            return _eventService.GetEventById(eventId);
        }
        [HttpPost]
        public ActionResult<Event> CreateEvent(EventDto dto)
        {
            return _eventService.AddEvent(dto);
        }
        [HttpPut("{eventId}")]
        public ActionResult<Event> UpdateEvent(int eventId, EventDto dto)
        {
            return _eventService.UpdateEvent(eventId, dto);
        }
        [HttpDelete("{eventId}")]
        public ActionResult<ApiResponse> DeleteEvent(int eventId)
        {
            return new ApiResponse { Message = _eventService.RemoveEvent(eventId) };
        }
        [HttpGet("date/{date}")]
        public ActionResult<IEnumerable<Event>> GetEventsByDate(string date)
        {
            return _eventService.GetEventsByDate(DateTime.Parse(date));

        }

    }
}
