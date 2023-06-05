using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class Community
{
    public int Id { get; set; }

    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsExclusive { get; set; }

    public bool IsPremium { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<CommunityMember> CommunityMembers { get; set; } = new List<CommunityMember>();
}
