using Microsoft.EntityFrameworkCore;

namespace EventOAPI.Tables
{
    public class EventDB : DbContext
    {
        public virtual DbSet<UserTable> Users { get; set; }
        public virtual DbSet<ChatTable> Chats { get; set; }
        public virtual DbSet<CommunityTable> Communities { get; set; }
        public virtual DbSet<EventTable> Events { get; set; }
        public virtual DbSet<ImageTable> Images { get; set; }
        public virtual DbSet<OwnerTable> Owners { get; set; }
        public virtual DbSet<SpaceTable> Spaces { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            const string STRCONN = @"Data Source=W-674PY03-1;Initial Catalog=EventO;Persist Security Info=True;User ID=sa;Password=Password@12345; TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(STRCONN);
        }
    }
}
