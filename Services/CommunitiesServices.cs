using EventOAPI.Data;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class CommunitiesServices
    {

        private readonly EventContext context;
        private readonly Models.EventService events;

        public CommunitiesServices(EventContext context, Models.EventService events)
        {
            this.context = context;
            this.events = events;
        }

            public List<Community> GetAllCommunities()
        {
            return context.Communities.ToList();
        }

        public bool AddCommunity(Community community)
        {
            try
            {
                context.Communities.Add(community);
                var user = events.GetUserById(community.UserId);
                user.CreatedCommunities.Add(community);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCommunity(int id)
        {
            try
            {
                var community = context.Communities.FirstOrDefault(c => c.Id == id);
                if (community != null)
                {
                    var user = events.GetUserById(community.UserId);
                    user.CreatedCommunities.Remove(community);
                    context.Communities.Remove(community);
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

        public bool UpdateCommunity(Community community)
        {
            try
            {
                var existingCommunity = context.Communities.FirstOrDefault(c => c.Id == community.Id);
                if (existingCommunity != null)
                {
                    var user = events.GetUserById(community.UserId);
                    user.CreatedCommunities.Remove(community);
                    existingCommunity.Name = community.Name;
                    existingCommunity.IsExclusive = community.IsExclusive;
                    existingCommunity.IsPremium = community.IsPremium;

                    user.CreatedCommunities.Add(existingCommunity);
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

        public Community GetCommunityById(int id)
        {
            return context.Communities.FirstOrDefault(c => c.Id == id)!;
        }

    }
}
