using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TokenAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}
