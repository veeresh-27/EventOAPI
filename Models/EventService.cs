namespace EventOAPI.Models
{
    public class EventService
    {
        private readonly EventContext context;

        public EventService(EventContext context)
        {
            this.context = context;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public bool AddUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveUser(int id)
        {
            try
            {
                var users = context.Users.ToList();
                var user = users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                {
                    context.Remove(user);
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

        public bool UpdateUser(User user)
        {
            try
            {
                var users = context.Users.ToList();
                var find = users.FirstOrDefault(u => u.Id == user.Id);
                if (find != null)
                {
                    find.Username = user.Username;
                    find.Password = user.Password;
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

        public User GetUserById(int id)
        {
            var users = context.Users.ToList();
            var user = users.FirstOrDefault(user => user.Id == id);
            return user!;
        }

        /// <summary>
        /// Admin
        /// </summary>
        /// <returns></returns>

        public List<Admin> GetAllAdmins()
        {
            return context.Admins.ToList();
        }

        public bool AddAdmin(Admin admin)
        {
            try
            {
                context.Admins.Add(admin);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAdmin(int id)
        {
            try
            {
                var admin = context.Admins.FirstOrDefault(a => a.Id == id);
                if (admin != null)
                {
                    foreach (var sp in admin.Spaces)
                    {
                        RemoveSpace(sp.Id);
                    }
                    context.Admins.Remove(admin);
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

        public bool UpdateAdmin(Admin admin)
        {
            try
            {
                var existingAdmin = context.Admins.FirstOrDefault(a => a.Id == admin.Id);
                if (existingAdmin != null)
                {
                    existingAdmin.Username = admin.Username;
                    existingAdmin.Password = admin.Password;
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

        public Admin GetAdminById(int id)
        {
            return context.Admins.FirstOrDefault(a => a.Id == id)!;
        }



        /*   Spaces      */

        public List<Space> GetAllSpaces()
        {
            return context.Spaces.ToList();
        }

        public bool AddSpace(Space space)
        {
            try
            {
                context.Spaces.Add(space);
                var admin = GetAdminById(space.AdminId);
                admin.Spaces.Add(space);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveSpace(int id)
        {
            try
            {
                var space = context.Spaces.FirstOrDefault(s => s.Id == id);
                if (space != null)
                {
                    context.Spaces.Remove(space);
                    var admin = GetAdminById(space.AdminId);
                    admin.Spaces.Remove(space);
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

        public bool UpdateSpace(Space space)
        {
            try
            {
                var existingSpace = context.Spaces.FirstOrDefault(s => s.Id == space.Id);
                if (existingSpace != null)
                {
                    var admin = GetAdminById(existingSpace.AdminId);
                    admin.Spaces.Remove(existingSpace);
                    existingSpace.Name = space.Name;
                    existingSpace.Capacity = space.Capacity;
                    existingSpace.Location = space.Location;
                    existingSpace.Amenities = space.Amenities;
                    admin.Spaces.Add(existingSpace);
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

        public Space GetSpaceById(int id)
        {
            return context.Spaces.FirstOrDefault(s => s.Id == id)!;
        }


        ///////////// Events
        public bool AddEvent(Event evnt)
        {
            try
            {
                context.Events.Add(evnt);
                var user = GetUserById(evnt.UserId);
                user.Events.Add(evnt);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveEvent(int id)
        {
            try
            {
                var evnt = context.Events.FirstOrDefault(e => e.Id == id);
                if (evnt != null)
                {
                    var user = GetUserById(evnt.UserId);
                    user.Events.Remove(evnt);
                    context.Events.Remove(evnt);
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

        public bool UpdateEvent(Event evnt)
        {
            try
            {
                var existingEvent = context.Events.FirstOrDefault(e => e.Id == evnt.Id);
                if (existingEvent != null)
                {
                    var user = GetUserById(evnt.UserId);
                    user.Events.Remove(evnt);
                    existingEvent.Name = evnt.Name;
                    existingEvent.SpaceId = evnt.SpaceId;
                    existingEvent.Date = evnt.Date;
                    existingEvent.Time = evnt.Time;
                    existingEvent.Duration = evnt.Duration;
                    existingEvent.Rules = evnt.Rules;
                    user.Events.Add(existingEvent);
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

        public Event GetEventById(int id)
        {
            return context.Events.FirstOrDefault(e => e.Id == id)!;
        }


        //////////////////Event Attendees


        public List<EventAttendee> GetAllEventAttendees()
        {
            return context.EventAttendees.ToList();
        }

        public bool AddEventAttendee(EventAttendee attendee)
        {
            try
            {
                context.EventAttendees.Add(attendee);
                var user = GetUserById(attendee.UserId);
                user.AttendedEvents.Add(attendee);
                var ev = GetEventById(attendee.EventId);
                ev.Attendees.Add(attendee);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveEventAttendee(int id)
        {
            try
            {
                var attendee = context.EventAttendees.FirstOrDefault(a => a.Id == id);
                if (attendee != null)
                {
                    var user = GetUserById(attendee.UserId);
                    user.AttendedEvents.Remove(attendee);
                    var ev = GetEventById(attendee.EventId);
                    ev.Attendees.Remove(attendee);
                    context.EventAttendees.Remove(attendee);
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

        public bool UpdateEventAttendee(EventAttendee attendee)
        {
            try
            {
                var existingAttendee = context.EventAttendees.FirstOrDefault(a => a.Id == attendee.Id);
                if (existingAttendee != null)
                {
                    var user = GetUserById(attendee.UserId);
                    user.AttendedEvents.Remove(attendee);
                    var ev = GetEventById(attendee.EventId);
                    ev.Attendees.Remove(attendee);
                    existingAttendee.UserId = attendee.UserId;
                    existingAttendee.EventId = attendee.EventId;
                    user.AttendedEvents.Add(attendee);
                    ev.Attendees.Add(attendee);
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

        public EventAttendee GetEventAttendeeById(int id)
        {
            return context.EventAttendees.FirstOrDefault(a => a.Id == id)!;
        }



        //////////////////////Communities

        public List<Community> GetAllCommunities()
        {
            return context.Communities.ToList();
        }

        public bool AddCommunity(Community community)
        {
            try
            {
                context.Communities.Add(community);
                var user = GetUserById(community.UserId);
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
                    var user = GetUserById(community.UserId);
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
                    var user = GetUserById(community.UserId);
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


        /////////////////////  Community Members

        public List<CommunityMember> GetAllCommunityMembers()
        {
            return context.CommunityMembers.ToList();
        }

        public bool AddCommunityMember(CommunityMember member)
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

        public bool UpdateCommunityMember(CommunityMember member)
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

        ///// Chats


        public List<Chat> GetAllChats()
        {
            return context.Chats.ToList();
        }

        public bool AddChat(Chat chat)
        {
            try
            {
                context.Chats.Add(chat);
                var user = GetUserById(chat.UserId);
                var comm = GetEventById(chat.EventId);
                user.Chats.Add(chat);
                comm.Chats.Add(chat);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveChat(int id)
        {
            try
            {
                var chat = context.Chats.FirstOrDefault(m => m.Id == id);
                if (chat != null)
                {
                    var user = GetUserById(chat.UserId);
                    var Event =GetEventById(chat.EventId);                 user.Chats.Remove(chat);
                    Event.Chats.Remove(chat);
                    context.Chats.Remove(chat);
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

       

        public Chat GetChatById(int id)
        {
            return context.Chats.FirstOrDefault(m => m.Id == id)!;
        }


        ////// POST
        ////

        public List<Post> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        public bool AddPost(Post post)
        {
            try
            {
                context.Posts.Add(post);  
                var Event = GetEventById(post.EventId);
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


        /////// Likes  
        ////

        public List<Like> GetAllLikes()
        {
            return context.Likes.ToList();
        }

        public bool AddLike(Like like)
        {
            try
            {
                context.Likes.Add(like);
                var post = GetPostById(like.PostId);
                post.Likes.Add(like);
                var Event = GetEventById(post.EventId);
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
                    var post = GetPostById(like.PostId);
                    post.Likes.Remove(like);
                    var Event = GetEventById(post.EventId);
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
