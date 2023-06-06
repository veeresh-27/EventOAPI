namespace EventOAPI.Dto
{
    public class SpaceDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public string Amenities { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
