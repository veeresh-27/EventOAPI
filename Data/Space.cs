using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class Space
{
    public int Id { get; set; }

    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public string Location { get; set; } = null!;

    public string? Amenities { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
