using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public virtual ICollection<Like> Likes { get; set; }


    }
}
