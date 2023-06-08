using EventOAPI.Dto;

namespace EventOAPI.Services
{
    public interface IAuthService
    {
        ApiResponse CheckEmail(string email);
        bool DeleteOwner(int adminId);
        bool DeleteUser(int userId);
        DetailsDto IsOwnerValid(LoginDto loginDto);
        DetailsDto IsUserValid(LoginDto loginDto);
        ApiResponse RegisterOwner(RegistrationDto dto);
        ApiResponse RegisterUser(RegistrationDto dto);
        bool UpdateOwner(int adminId, DetailsDto dto);
        bool UpdateUser(int adminId, DetailsDto dto);
    }
}