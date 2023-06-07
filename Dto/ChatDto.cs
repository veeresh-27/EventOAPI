namespace EventOAPI.Dto
{
    public class ChatDto
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; } = null!;

    }
}
