using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class Community
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsPremium { get; set; }
        public double Price { get; set; }
        public int InviteTokenId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User user { get; set; } = null!;
        public virtual ICollection<CommunityMember> Members { get; set; } = new List<CommunityMember>();
        public virtual ICollection<Event> CommunityEvents { get; set; } = new List<Event>();
    }
}
