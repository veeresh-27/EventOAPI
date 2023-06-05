using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class UserToken
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TokenAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
