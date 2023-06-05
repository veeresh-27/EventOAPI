using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class Event
{
    public int Id { get; set; }

    public int SpaceId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public int Duration { get; set; }

    public string? Rules { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();

    public virtual Space Space { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
