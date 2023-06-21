using AWAIT.DAL;
using Microsoft.EntityFrameworkCore;

namespace SeleniumRecorderApi.Data
{
    public class AwaitDbContext : DbContext
    {
        public AwaitDbContext(DbContextOptions<AwaitDbContext> options)
            : base(options) { }
        public DbSet<EventPropertyTargetModel>? EPTs { get; set; }
        public DbSet<SuitModel> Suits { get; set; }
        public DbSet<TestModel> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventPropertyTargetModel>().ToTable("EPTs");
            modelBuilder.Entity<SuitModel>().ToTable("SuitModel");
            modelBuilder.Entity<TestModel>().ToTable("TestModel");
            modelBuilder.Entity<EventModel>().ToTable("EventModel");
            modelBuilder.Entity<TargetModel>().ToTable("TargetModel");
            modelBuilder.Entity<TargetTypeModel>().ToTable("TargetTypeModel");

        }

    }
}
