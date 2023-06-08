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
            return _context.Users.FirstOrDefault(u => u.Id.Equals(userId))!;
        }

        public List<EventAttendee> GetEventsAttendedByUser(int userId)
        {
            return _context.Users.Include(u => u.AttendedEvents).FirstOrDefault(u => u.Id.Equals(userId))!.AttendedEvents.ToList();
        }

        public List<Event> GetEventsCreatedByUser(int userId)
        {
            return _context.Users.Include(u => u.Events).FirstOrDefault(u => u.Id.Equals(userId))!.Events.ToList();
        }


        public List<Chat> GetUserChats(int userId)
        {
            return _context.Users.Include(u => u.Chats).FirstOrDefault(u => u.Id.Equals(userId))!.Chats.ToList();
        }

        public List<Community> GetUserCreatedCommunities(int userId)
        {
            return _context.Users.Include(u => u.CreatedCommunities).FirstOrDefault(u => u.Id.Equals(userId))!.CreatedCommunities.ToList();
        }

        public List<CommunityMember> GetUserJoinedCommunities(int userId)
        {
            return _context.Users.Include(u => u.Communities).FirstOrDefault(u => u.Id.Equals(userId))!.Communities.ToList();
        }
    }
}
