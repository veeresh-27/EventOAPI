using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("user/login")]
        public ActionResult<ApiResponse> UserLogin(LoginDto login)
        {
            return _authService.IsUserValid(login);
        }

        [HttpPost("user/register")]
        public ActionResult<ApiResponse> UserRegister(RegistrationDto dto)
        {
            return _authService.RegisterUser(dto);
        }
        [HttpPost("owner/login")]
        public ActionResult<ApiResponse> OwnerLogin(LoginDto login)
        {
            return _authService.IsOwnerValid(login);
        }

        [HttpPost("owner/register")]
        public ActionResult<ApiResponse> OwnerRegister(RegistrationDto dto)
        {
            return _authService.RegisterOwner(dto);
        }
    }
}
