using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
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
        [HttpGet("{eventId}/attendees")]
        public ActionResult<IEnumerable<DetailsDto>> GetAttendiesOfAnEvent(int eventId)
        {
            return _eventService.GetAttendeesOfAnEvent(eventId);
        }
        [HttpPost("{eventId}/attendees/{userId}")]
        public ActionResult<ApiResponse> AddAttendeeToAnEvent(int eventId, int userId)
        {
            return new ApiResponse { Message = _eventService.AddAttendeeToAnEvent(eventId, userId) };
        }
        [HttpDelete("{eventId}/attendees/{userId}")]
        public ActionResult<ApiResponse> DeleteAttendeeFromAnEvent(int eventId, int userId)
        {
            return new ApiResponse { Message = _eventService.DeleteAttendeeFromAnEvent(eventId, userId) };
        }
        [HttpPost("{eventId}/like")]
        public ActionResult<ApiResponse> AddLikeToAnEvent(int eventId)
        {
            return new ApiResponse { Message = _eventService.AddLike(eventId) };
        }
        [HttpPost("{eventId}/dislike")]
        public ActionResult<ApiResponse> RemoveLikeFromAnEvent(int eventId)
        {
            return new ApiResponse { Message = _eventService.DeleteLike(eventId) };
        }
        [HttpGet("{eventId}/chat")]
        public ActionResult<IEnumerable<Chat>> GetChat(int eventId)
        {
            return _eventService.GetChatsOfAnEvent(eventId);
        }
        [HttpPost("{eventId}/chat")]
        public ActionResult<ApiResponse> GetChat(int eventId, ChatDto dto)
        {
            return new ApiResponse { Message = _eventService.AddChat(eventId, dto) };
        }



    }
}
