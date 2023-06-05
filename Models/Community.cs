using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class Community
    {
        [Key]
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsPremium { get; set; }
        public DateTime CreatedAt { get; set; }

        public Admin Admin { get; set; }
        public virtual ICollection<CommunityMember> Members { get; set; }
    }
}
