using SeleniumRecorderApi.Data;
using SeleniumRecorderApi.Models;

namespace SeleniumRecorderApi.Services
{
    public class SeleniumRepository
    {
        SeleniumTestContext context { get; set; }
        public SeleniumRepository(SeleniumTestContext context) { this.context = context; }

        public Task<IQueryable<SeleniumTestModel>> GetAllTests()
        {
            return Task.FromResult(context.SeleniumTest.AsQueryable());
        }

        public async Task<SeleniumTestModel> GetTest(int id) => await context.SeleniumTest.FindAsync(id);

        public SeleniumTestModel GetTest(string name) => context.SeleniumTest.FirstOrDefault(x => x.Name == name);

        public SeleniumTestModel CreateTest(SeleniumTestModel model)
        {
            context.SeleniumTest.Add(model);
            context.SaveChanges();
            return model;
        }
    }
}
