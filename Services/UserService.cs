using EventOAPI.Data;
using EventOAPI.Dto;
using EventOAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventOAPI.Services
{
    public class UserService : IUserService
    {
        private readonly EventContext _context;

        public UserService(EventContext context)
        {
            _context = context;
        }

        public List<DetailsDto> GetAllUsers()
        {
            return _context.Users.Select(u => new DetailsDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            }).ToList();
        }
        public User GetUserById(int userId)
        {
            return _context.Users.Include(u => u.Events).Include(u => u.AttendedEvents).Include(u => u.CreatedCommunities).Include(u => u.Communities).Include(u => u.Chats).FirstOrDefault(u => u.Id.Equals(userId))!;
        }

        public List<EventAttendee> GetEventsAttendedByUser(int userId)
        {
            return GetUserById(userId).AttendedEvents.ToList();
        }

        public List<Event> GetEventsCreatedByUser(int userId)
        {
            return GetUserById(userId).Events.ToList();
        }


        public List<Chat> GetUserChats(int userId)
        {
            return GetUserById(userId).Chats.ToList();
        }

        public List<Community> GetUserCreatedCommunities(int userId)
        {
            return GetUserById(userId).CreatedCommunities.ToList();
        }

        public List<CommunityMember> GetUserJoinedCommunities(int userId)
        {
            return GetUserById(userId).Communities.ToList();
        }
    }
}
