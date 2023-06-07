using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Models
{
    public class InviteToken
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CommunityId { get; set; }
        public Guid Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
