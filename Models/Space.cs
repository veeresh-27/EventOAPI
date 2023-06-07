using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Models
{
    public class Space
    {
        [Key]
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public string? Location { get; set; }
        public string? Amenities { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public Admin Admin { get; set; } = null!;
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
