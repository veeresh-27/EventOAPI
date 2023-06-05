using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class Admin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Community> Communities { get; set; } = new List<Community>();

    public virtual ICollection<Space> Spaces { get; set; } = new List<Space>();
}
