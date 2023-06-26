using AWAIT.DAL;
using Microsoft.EntityFrameworkCore;

namespace SeleniumRecorder.DAL
{
    public class AwaitDbContext : DbContext
    {
        public AwaitDbContext(DbContextOptions<AwaitDbContext> options)
            : base(options) { }
        // [EPT: EVENT-PROPERTY-TARGET-INDEX]
        public DbSet<EventPropertyTargetModel>? EPTs { get; set; }
        // [TEST SUIT TABLES]
        public DbSet<SuitModel>? Suits { get; set; }
        public DbSet<TestModel>? Tests { get; set; }
        // [EVENT TARGET TABLES]
        public DbSet<EventModel>? Events { get; set; }
        public DbSet<TargetModel>? Targets { get; set; }
        public DbSet<TargetTypeModel>? TargetTypes { get; set; }
        // [USERS TABLE]
        public DbSet<UserModel>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OVERRIDE: EventPropertyTargetModel =>[EPTs]
            modelBuilder.Entity<EventPropertyTargetModel>().ToTable("EPTs");
            // OVERRIDE: SuitModel =>[Suits]
            modelBuilder.Entity<SuitModel>().ToTable("Suits");
            // OVERRIDE: TestModel =>[Tests]
            modelBuilder.Entity<TestModel>().ToTable("Tests");
            // OVERRIDE: EventModel =>[Events]
            modelBuilder.Entity<EventModel>().ToTable("Events");
            // OVERRIDE: TargetModel =>[Targets]
            modelBuilder.Entity<TargetModel>().ToTable("Targets");
            // OVERRIDE: TargetTypeModel =>[TargetTypes]
            modelBuilder.Entity<TargetTypeModel>().ToTable("TargetTypes");
            // OVERRIDE: UserModel =>[Users]
            modelBuilder.Entity<UserModel>().ToTable("Users");

        }

    }
}
