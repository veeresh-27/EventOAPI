using EventOAPI.Dto;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public interface IUserService
    {
        List<DetailsDto> GetAllUsers();
        List<EventAttendee> GetEventsAttendedByUser(int userId);
        List<Event> GetEventsCreatedByUser(int userId);
        User GetUserById(int userId);
        List<Chat> GetUserChats(int userId);
        List<Community> GetUserCreatedCommunities(int userId);
        List<CommunityMember> GetUserJoinedCommunities(int userId);
    }
}