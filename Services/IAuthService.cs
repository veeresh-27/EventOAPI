using EventOAPI.Dto;

namespace EventOAPI.Services
{
    public interface IAuthService
    {
        DetailsDto IsOwnerValid(LoginDto loginDto);
        DetailsDto IsUserValid(LoginDto loginDto);
        ApiResponse RegisterOwner(RegistrationDto dto);
        ApiResponse RegisterUser(RegistrationDto dto);
        bool UpdateOwner(int adminId, DetailsDto dto);
        bool UpdateUser(int adminId, DetailsDto dto);
    }
}