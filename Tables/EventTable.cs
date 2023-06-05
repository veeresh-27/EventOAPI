using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Tables
{
        [Table("EventTable")]
    public class EventTable
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;

        public string EventDescription { get; set; } = string.Empty;
        [Required]
        public string EventType { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }

        public DateTime EventDate { get; set; }

        public UserTable Creator { get; set; }

        public CommunityTable Community { get; set; }

        public List<UserTable> Attendees { get; set; }

        public SpaceTable Space { get; set; }

        public List<ImageTable> EventImages { get; set; }

    }
}
