using AWAIT.DAL;
using Microsoft.EntityFrameworkCore;
using SeleniumRecorder.DAL;

namespace SeleniumRecorder.Services
{
    public class WebSerivce
    {
        private readonly AwaitDbContext _context;

        public WebSerivce(AwaitDbContext context)
        {
            _context = context;
        }
        public async Task AddTestSuit(TestSuitModel testSuitModel)
        {
            var testModel = new TestModel();
            var suitModel = new TestSuitModel
            {
                SuitName = testSuitModel.SuitName,
                SuitType = testSuitModel.SuitType,
                SuitDescription = testSuitModel.SuitDescription,
            };
        }
        public async Task AddEventData(EventDataModel eventDataModel)
        {
            _context.Add(eventDataModel);
            await _context.SaveChangesAsync();
        }
        public async Task AddUser()
        {

        }
        public void UpdateUser()
        {

        }
        public void DeleteUser()
        {

        }
    }
}
