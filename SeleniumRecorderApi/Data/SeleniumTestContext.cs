using Microsoft.EntityFrameworkCore;
using SeleniumRecorderApi.Models;

namespace SeleniumRecorderApi.Data
{
    public class SeleniumTestContext: DbContext
    {
        public SeleniumTestContext(DbContextOptions<SeleniumTestContext> options) : base(options) { }

        public DbSet<SeleniumTestModel> SeleniumTest { get; set; }
    }
}
