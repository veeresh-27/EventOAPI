using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class CommunityMember
    {
        [Key]
        public int Id { get; set; }
        public int CommunityId { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; }

        public Community Community { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
