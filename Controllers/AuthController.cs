using EventOAPI.Dto;
using EventOAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EventContext _eventContext;

        public AuthController(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        [HttpPost("/user/login")]
        public IActionResult UserLogin(LoginDto login)
        {
            _eventContext.
        }
    }
}
