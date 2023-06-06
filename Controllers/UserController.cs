using EventOAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EventService _service;

        public UserController(EventService service)
        {
            _service = service;
        }

        [HttpGet("/allusers")]
        public IEnumerable<User> GetAllUsers()
        {
            return _service.GetAllUsers();
        }
    }
}
