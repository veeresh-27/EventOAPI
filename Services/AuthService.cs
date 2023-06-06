using EventOAPI.Dto;
using EventOAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace EventOAPI.Services
{
    public class AuthService
    {

        private readonly EventContext _eventContext;

        public AuthService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }
       
        public ApiResponse IsUserValid(LoginDto loginDto)
        {
            var foundUser = _eventContext.Users.FirstOrDefault(user => (user.Email.Equals(loginDto.Email) && user.Password.Equals(loginDto.Password)));
            if (foundUser != null)
            {
                return new ApiResponse
                {
                    Message = true
                };
            }
            return new ApiResponse { Message = false };

        }
        public ApiResponse RegisterUser(RegistrationDto dto)
        {
            try
            {
                _eventContext.Users.Add(new User { Email = dto.Email, Username = dto.Username, Password = dto.Password, CreatedAt=DateTime.Now });
                _eventContext.SaveChanges();
                return new ApiResponse { Message = true };

            }
            catch (Exception)
            {
                return new ApiResponse() { Message = false };
            }
        }
        public ApiResponse IsOwnerValid(LoginDto loginDto)
        {
            var foundUser = _eventContext.Admins.FirstOrDefault(user => (user.Email.Equals(loginDto.Email) && user.Password.Equals(loginDto.Password)));
            if (foundUser != null)
            {
                return new ApiResponse
                {
                    Message = true
                };
            }
            return new ApiResponse { Message = false };

        }
        public ApiResponse RegisterOwner(RegistrationDto dto)
        {
            try
            {
                _eventContext.Admins.Add(new Admin { Email = dto.Email, Username = dto.Username, Password = dto.Password, CreatedAt=DateTime.Now });
                _eventContext.SaveChanges();
                return new ApiResponse { Message = true };

            }
            catch (Exception)
            {
                return new ApiResponse() { Message = false };
            }
        }

    }
}
