using EventOAPI.Dto;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public interface IAdminServices
    {
        Space AddSpaceToOwner(int ownerId, SpaceDto dto);
        List<DetailsDto> GetAllAdmins();
        List<Space> GetSpacesByOwnerId(int ownerId);
        bool RemoveSpaceByOwnerId(int ownerId, int spaceId);
        bool UpdateSpace(int ownerId, int spaceId, SpaceDto spaceDto);
    }
}