using System;
using System.Collections.Generic;

namespace EventOAPI.Data;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<CommunityMember> CommunityMembers { get; set; } = new List<CommunityMember>();

    public virtual ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
