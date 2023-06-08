using EventOAPI.Dto;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public interface ICommunitiesServices
    {
        Community AddCommunity(CommunityDto community);
        bool AddEventToCommunity(int communityId, int eventId);
        bool AddMembeToCommunity(int communityId, int memberId);
        bool DeleteEventFromCommunity(int communityId, int eventId);
        List<Community> GetAllCommunities();
        Community GetCommunityById(int id);
        List<Event> GetCommunityEvents(int communityId);
        List<DetailsDto> GetCommunityMembers(int communityId);
        bool RemoveCommunity(int id);
        bool RemoveMemberFromCommunity(int communityId, int memberId);
        Community UpdateCommunity(int Id, CommunityDto community);
    }
}