using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int SpaceId { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Duration { get; set; }
        public string Rules { get; set; }
        public DateTime CreatedAt { get; set; }

        public Space Space { get; set; }
        public User User { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<EventAttendee> Attendees { get; set; }
    }
}
