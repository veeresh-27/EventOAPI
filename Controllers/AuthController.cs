using EventOAPI.Dto;
using EventOAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("isvalid")]
        public ActionResult<ApiResponse> CheckEmail(string email)
        {
            return _authService.CheckEmail(email);
        }

        [HttpPost("user/login")]
        public ActionResult<DetailsDto> UserLogin(LoginDto login)
        {
            return _authService.IsUserValid(login);
        }

        [HttpPost("user/register")]
        public ActionResult<ApiResponse> UserRegister(RegistrationDto dto)
        {
            return _authService.RegisterUser(dto);
        }
        [HttpPost("owner/login")]
        public ActionResult<DetailsDto> OwnerLogin(LoginDto login)
        {
            return _authService.IsOwnerValid(login);
        }

        [HttpPost("owner/register")]
        public ActionResult<ApiResponse> OwnerRegister(RegistrationDto dto)
        {
            return _authService.RegisterOwner(dto);
        }
        [HttpDelete("owner/{id}")]
        public ActionResult<ApiResponse> DeleteOwner(int id)
        {
            return new ApiResponse { Message = _authService.DeleteOwner(id) };
        }
        [HttpPut("owner/{id}")]
        public ActionResult<ApiResponse> UpdateOwner(int ownerId, DetailsDto dto)
        {
            return new ApiResponse { Message = _authService.UpdateOwner(ownerId, dto) };
        }
        [HttpDelete("user/{id}")]
        public ActionResult<ApiResponse> DeleteUser(int id)
        {
            return new ApiResponse { Message = _authService.DeleteUser(id) };
        }
        [HttpPut("user/{id}")]
        public ActionResult<ApiResponse> UpdateUserr(int userId, DetailsDto dto)
        {
            return new ApiResponse { Message = _authService.UpdateUser(userId, dto) };
        }
    }
}
