using EventOAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EventOAPI.Data
{
    public class EventContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public EventContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Space> Spaces { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventAttendee> EventAttendees { get; set; }

        public DbSet<Community> Communities { get; set; }

        public DbSet<CommunityMember> CommunityMembers { get; set; }

        public DbSet<InviteToken> InviteTokens { get; set; }

        public DbSet<Chat> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string for your database
            optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseSqlServer(_configuration.GetConnectionString("faiserver"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships between entities
            modelBuilder.Entity<Admin>()
                .HasMany(s => s.Spaces)
                .WithOne(c => c.Admin)
                .HasForeignKey(a => a.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Space>()
                .HasOne(s => s.Admin)
                .WithMany(a => a.Spaces)
                .HasForeignKey(s => s.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Space)
                .WithMany(s => s.Events)
                .HasForeignKey(e => e.SpaceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventAttendee>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Attendees)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventAttendee>()
                .HasOne(a => a.User)
                .WithMany(u => u.AttendedEvents)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommunityMember>()
                .HasOne(m => m.Community)
                .WithMany(c => c.Members)
                .HasForeignKey(m => m.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommunityMember>()
                .HasOne(m => m.User)
                .WithMany(u => u.Communities)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Event)
                .WithMany(e => e.Chats)
                .HasForeignKey(c => c.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InviteToken>()
                .Property(b => b.Token)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
