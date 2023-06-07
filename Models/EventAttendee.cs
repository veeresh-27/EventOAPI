using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class EventAttendee
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; }

        public Event Event { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
