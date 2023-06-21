using AWAIT.DAL;
using Microsoft.EntityFrameworkCore;

namespace SeleniumRecorder.DAL
{
    public class AwaitDbContext : DbContext
    {
        public AwaitDbContext(DbContextOptions<AwaitDbContext> options)
            : base(options) { }
        public DbSet<EventPropertyTargetModel>? EPTs { get; set; }
        public DbSet<SuitModel> Suits { get; set; }
        public DbSet<TestModel> Tests { get; set; }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<TargetModel> Targets { get; set; }
        public DbSet<TargetTypeModel> TargetTypes { get; set; }
        // [USERS TABLE]
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventPropertyTargetModel>().ToTable("EPTs");
            modelBuilder.Entity<SuitModel>().ToTable("Suits");
            modelBuilder.Entity<TestModel>().ToTable("Tests");
            modelBuilder.Entity<EventModel>().ToTable("Events");
            modelBuilder.Entity<TargetModel>().ToTable("Targets");
            modelBuilder.Entity<TargetTypeModel>().ToTable("TargetTypes");
            // [USERS TABLE]
            modelBuilder.Entity<UserModel>().ToTable("Users");

        }

    }
}
