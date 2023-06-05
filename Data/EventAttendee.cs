using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class EventAttendee
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int UserId { get; set; }

    public DateTime? JoinedAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
