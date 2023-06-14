using Microsoft.EntityFrameworkCore;
using SeleniumRecorder.Models;

namespace SeleniumRecorder.DAL
{
    public class AwaitDbContext : DbContext
    {
        public AwaitDbContext(DbContextOptions<AwaitDbContext> options)
            : base(options) { }
        // [DISABLED FOR MIGRATION PURPOSES] public DbSet<UserModel>? Users { get; set; }
        public DbSet<WebElementDataModel>? WebElements { get; set; }

    }
}
