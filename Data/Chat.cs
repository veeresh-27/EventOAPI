using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class Chat
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? SentAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
