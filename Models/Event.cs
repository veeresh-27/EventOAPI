using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int SpaceId { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string? Rules { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Price { get; set; } 
         
        public Space Space { get; set; } = null!;
        public User User { get; set; } = null!;

        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public virtual ICollection<EventAttendee> Attendees { get; set; } = new List<EventAttendee>();
    }
}
