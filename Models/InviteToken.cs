using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class InviteToken
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CommunityId { get; set; }
        public string? Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
