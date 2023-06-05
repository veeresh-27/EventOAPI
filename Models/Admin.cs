using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Space> Spaces { get; set; }
    }
}
