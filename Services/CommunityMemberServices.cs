using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class CommunityMemberServices
    {
        private readonly EventContext context;

        public CommunityMemberServices(EventContext context)
        {
            this.context = context;
        }
        public List<CommunityMember> GetAllCommunityMembers()
        {
            return context.CommunityMembers.ToList();
        }

        public bool AddCommunityMember(CommunityMemberServices member)
        {
            try
            {
                context.CommunityMembers.Add(member);
                var user = GetUserById(member.UserId);
                var comm = GetCommunityById(member.CommunityId);
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
                    var user = GetUserById(member.UserId);
                    var comm = GetCommunityById(member.CommunityId);
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

        public bool UpdateCommunityMember(CommunityMemberServices member)
        {
            try
            {
                var existingMember = context.CommunityMembers.FirstOrDefault(m => m.Id == member.Id);
                if (existingMember != null)
                {

                    var user = GetUserById(existingMember.UserId);
                    var comm = GetCommunityById(existingMember.CommunityId);
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
