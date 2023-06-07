using EventOAPI.Data;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class PostServices
    {
        private readonly EventContext context;
        private readonly EventService events;

        public PostServices(EventContext context, EventService events)
        {
            this.context = context;
            this.events = events;
        }
        public List<Post> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        public bool AddPost(Post post)
        {
            try
            {
                context.Posts.Add(post);
                var Event = events.GetEventById(post.EventId);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemovePost(int id)
        {
            try
            {
                var post = context.Posts.FirstOrDefault(m => m.Id == id);
                if (post != null)
                {
                    context.Posts.Remove(post);
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

        public bool UpdatePost(Post post)
        {
            try
            {
                var existingPost = context.Posts.FirstOrDefault(m => m.Id == post.Id);
                if (existingPost != null)
                {
                    existingPost.Title = post.Title;
                    existingPost.Description = post.Description;

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

        public Post GetPostById(int id)
        {
            return context.Posts.FirstOrDefault(m => m.Id == id)!;
        }

    }
}
