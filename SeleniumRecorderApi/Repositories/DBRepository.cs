using AWAIT.DAL;
using SeleniumRecorderApi.Data;
using SeleniumRecorderApi.Interfaces;

namespace SeleniumRecorderApi.Repositories
{

    public class DBRepository : IDBRepository
    {
        private readonly AwaitDbContext _context;

        public async Task<IEnumerable<TestModel>> GetTests(int suitId)
        {
            return await Task.Factory.StartNew(() => _context.Tests.Where(x => x.SuitId == suitId));
        }

        public async Task<SuitModel> GetTestSuite(int id) => await _context.Suits.FindAsync(id);
    }
}
