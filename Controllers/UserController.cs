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
        private readonly EventService _service;

        public UserController(EventService service)
        {
            _service = service;
        }

        //[HttpGet("/allusers")]
        //public ActionResult<IEnumerable<User>> GetAllUsers()
        //{
        //    return _service.GetAllUsers();
        //}
    }
}
