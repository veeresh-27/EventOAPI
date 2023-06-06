using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class CommunityMemberServices
    {
        private readonly EventContext context;
        private readonly EventService eventService;
        private readonly CommunitiesServices community;

        public CommunityMemberServices(EventContext context, EventService eventService, CommunitiesServices community)
        {
            this.context = context;
            this.eventService = eventService; 
            this.community = community;
        }
        public List<CommunityMember> GetAllCommunityMembers()
        {
            return context.CommunityMembers.ToList();
        }

        public bool AddCommunityMember(CommunityMember member)
        {
            try
            {
                context.CommunityMembers.Add(member);
                var user = eventService.GetUserById(member.UserId);
                var comm = community.GetCommunityById(member.CommunityId);
                user.Communities.Add(member);
                comm.Members.Add(member);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCommunityMember(int id)
        {
            try
            {
                var member = context.CommunityMembers.FirstOrDefault(m => m.Id == id);
                if (member != null)
                {
                    var user = eventService.GetUserById(member.UserId);
                    var comm = community.GetCommunityById(member.CommunityId);
                    user.Communities.Remove(member);
                    comm.Members.Remove(member);
                    context.CommunityMembers.Remove(member);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCommunityMember(CommunityMember member)
        {
            try
            {
                var existingMember = context.CommunityMembers.FirstOrDefault(m => m.Id == member.Id);
                if (existingMember != null)
                {

                    var user = eventService.GetUserById(existingMember.UserId);
                    var comm = community.GetCommunityById(existingMember.CommunityId);
                    user.Communities.Remove(existingMember);
                    comm.Members.Remove(existingMember);
                    existingMember.UserId = member.UserId;
                    existingMember.CommunityId = member.CommunityId;

                    user.Communities.Add(existingMember);
                    comm.Members.Add(existingMember);
                    // Update other properties as needed
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CommunityMember GetCommunityMemberById(int id)
        {
            return context.CommunityMembers.FirstOrDefault(m => m.Id == id)!;
        }
    }
}
