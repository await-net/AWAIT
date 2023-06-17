using AWAIT.DAL;
using Microsoft.EntityFrameworkCore;

namespace SeleniumRecorder.DAL
{
    public class AwaitDbContext : DbContext
    {
        public AwaitDbContext(DbContextOptions<AwaitDbContext> options)
            : base(options) { }
        public DbSet<EventDataModel>? EventData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDataModel>().ToTable("EventData");
        }

    }
}
