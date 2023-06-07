using EventOAPI.Data;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class LikeServices
    {

        private readonly EventContext context;
        private readonly PostServices postServices;
        private readonly EventService events;

        public LikeServices(EventContext context, PostServices postServices, EventService events)
        {
            this.context = context;
            this.postServices = postServices;   
            this.events = events;
        }
        public List<Like> GetAllLikes()
        {
            return context.Likes.ToList();
        }

        public bool AddLike(Like like)
        {
            try
            {
                context.Likes.Add(like);
                var post = postServices.GetPostById(like.PostId);
                post.Likes.Add(like);
                var Event = events.GetEventById(post.EventId);
                Event.Likes.Add(like);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveLike(int id)
        {
            try
            {
                var like = context.Likes.FirstOrDefault(m => m.Id == id);
                if (like != null)
                {
                    context.Likes.Add(like);
                    var post = postServices.GetPostById(like.PostId);
                    post.Likes.Remove(like);
                    var Event = events.GetEventById(post.EventId);
                    Event.Likes.Remove(like);
                    context.Likes.Remove(like);
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

        public Like GetLikeById(int id)
        {
            return context.Likes.FirstOrDefault(m => m.Id == id)!;
        }



    }
}
