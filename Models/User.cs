using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
        public List<EventAttendee> AttendedEvents { get; set; } = new List<EventAttendee>();
        public List<Community> CreatedCommunities { get; set; } = new List<Community>();
        public List<CommunityMember> Communities { get; set; } = new List<CommunityMember>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
