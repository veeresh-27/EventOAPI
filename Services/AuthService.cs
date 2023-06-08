using EventOAPI.Data;
using EventOAPI.Dto;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class AuthService : IAuthService
    {

        private readonly EventContext _eventContext;

        public AuthService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }
        public DetailsDto IsUserValid(LoginDto loginDto)
        {
            var foundUser = _eventContext.Users.FirstOrDefault(user => (user.Email!.Equals(loginDto.Email) && user.Password!.Equals(loginDto.Password)));
            if (foundUser != null)
            {
                return new DetailsDto
                {
                    Id = foundUser.Id,
                    Username = foundUser.Username,
                    Email = foundUser.Email,
                };
            }
            return new DetailsDto { };

        }
        public ApiResponse RegisterUser(RegistrationDto dto)
        {
            try
            {
                _eventContext.Users.Add(new User { Email = dto.Email, Username = dto.Username, Password = dto.Password, CreatedAt = DateTime.Now });
                _eventContext.SaveChanges();
                return new ApiResponse { Message = true };

            }
            catch (Exception)
            {
                return new ApiResponse() { Message = false };
            }
        }
        public DetailsDto IsOwnerValid(LoginDto loginDto)
        {
            var foundUser = _eventContext.Admins.FirstOrDefault(user => (user.Email!.Equals(loginDto.Email) && user.Password!.Equals(loginDto.Password)));
            if (foundUser != null)
            {
                return new DetailsDto
                {
                    Id = foundUser.Id,
                    Username = foundUser.Username,
                    Email = foundUser.Email,
                };

            }
            return new DetailsDto { };

        }
        public ApiResponse RegisterOwner(RegistrationDto dto)
        {
            try
            {
                _eventContext.Admins.Add(new Admin { Email = dto.Email, Username = dto.Username, Password = dto.Password, CreatedAt = DateTime.Now });
                _eventContext.SaveChanges();
                return new ApiResponse { Message = true };

            }
            catch (Exception)
            {
                return new ApiResponse() { Message = false };
            }
        }
        public ApiResponse CheckEmail(string email)
        {
            var res = _eventContext.Admins.Any(a => a.Email!.Equals(email)) || _eventContext.Users.Any(u => u.Email!.Equals(email));
            if (res)
            {
                return new ApiResponse
                {
                    Message = false
                };

            }
            return new ApiResponse { Message = true };
        }
        public bool DeleteOwner(int adminId)
        {
            try
            {
                var admin = _eventContext.Admins.FirstOrDefault(a => a.Id.Equals(adminId));
                if (admin != null)
                {
                    _eventContext.Admins.Remove(admin);
                    _eventContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool UpdateOwner(int adminId, DetailsDto dto)
        {
            try
            {
                var admin = _eventContext.Admins.FirstOrDefault(a => a.Id.Equals(adminId));
                if (admin != null)
                {
                    admin.Username = dto.Username;
                    admin.Password = dto.Password;
                    admin.Email = dto.Email;
                    _eventContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteUser(int userId)
        {
            try
            {
                var admin = _eventContext.Users.FirstOrDefault(a => a.Id.Equals(userId));
                if (admin != null)
                {
                    _eventContext.Users.Remove(admin);
                    _eventContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool UpdateUser(int adminId, DetailsDto dto)
        {
            try
            {
                var admin = _eventContext.Users.FirstOrDefault(a => a.Id.Equals(adminId));
                if (admin != null)
                {
                    admin.Username = dto.Username;
                    admin.Password = dto.Password;
                    admin.Email = dto.Email;
                    _eventContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
