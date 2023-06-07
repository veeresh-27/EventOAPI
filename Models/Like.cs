using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Models
{
    [Table("Like")]
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? comment { get; set; }
        public User User { get; set; } = null!;

        public Post Post { get; set; } = null!;
    }
}
