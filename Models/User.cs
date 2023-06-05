using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Event> Events { get; set; }
        public List<EventAttendee> AttendedEvents { get; set; }
        public List<CommunityMember> Communities { get; set; }
        public List<UserToken> Tokens { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
