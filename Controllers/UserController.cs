using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("/all")]
        public ActionResult<IEnumerable<DetailsDto>> GetAllUsers()
        {
            return _service.GetAllUsers();
        }
        [HttpGet("{userId}")]
        public ActionResult<User> GetUser(int userId)
        {
            return _service.GetUserById(userId);
        }
        [HttpGet("{userId}/events/created")]
        public ActionResult<IEnumerable<Event>> GetUserCreatedEvents(int userId)
        {
            return _service.GetEventsCreatedByUser(userId);
        }
        [HttpGet("{userId}/events/attended")]
        public ActionResult<IEnumerable<EventAttendee>> GetUserAttendedEvents(int userId)
        {
            return _service.GetEventsAttendedByUser(userId);
        }
        [HttpGet("{userId}/communities/created")]
        public ActionResult<IEnumerable<Community>> GetUserCreatedCommunities(int userId)
        {
            return _service.GetUserCreatedCommunities(userId);
        }
        [HttpGet("{userId}/communities/joined")]
        public ActionResult<List<CommunityMember>> GetUserJoinedCommunities(int userId)
        {
            return _service.GetUserJoinedCommunities(userId);
        }
        [HttpGet("{userId}/chats")]
        public ActionResult<IEnumerable<Chat>> GetUserChats(int userId)
        {
            return _service.GetUserChats(userId);
        }

    }
}
