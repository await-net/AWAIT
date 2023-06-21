using AWAIT.DAL;

namespace SeleniumRecorderApi.Interfaces
{
    public interface IDBRepository
    {
        Task<SuitModel> GetTestSuite(int id);
        Task<IEnumerable<TestModel>> GetTests(int suitId);
    }
}
