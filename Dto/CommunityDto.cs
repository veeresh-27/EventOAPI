namespace EventOAPI.Dto
{
    public class CommunityDto
    {
        public int OwnerId { get; set; }
        public string? Name { get; set; }
        public bool IsExclusive { get; set; }
        public bool IsPremium { get; set; }
        public double Price { get; set; }

    }
}
