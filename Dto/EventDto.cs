namespace EventOAPI.Dto
{
    public class EventDto
    {
        public int SpaceId { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string? Rules { get; set; }
        public double Price { get; set; }

    }
}
