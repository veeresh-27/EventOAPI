using EventOAPI.Models;

namespace EventOAPI.Services
{
    public interface ISpaceService
    {
        List<Space> GetAllSpaces();
        List<Event> GetEventsOfASpace(int spaceId);
        Space GetSpaceById(int spaceId);
    }
}