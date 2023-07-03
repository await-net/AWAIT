using AWAIT.DAL;
using Microsoft.EntityFrameworkCore;
using SeleniumRecorder.DAL;
using SeleniumRecorder.Models;

namespace SeleniumRecorder.Services
{
    public class WebService
    {
        private readonly AwaitDbContext _dbContext;
        public WebService(AwaitDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Provides Application with Service: Create/Add a new Recorder to a Suit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<RecorderModel> ServiceCreateRecorder(SuitRecorderView model)
        {
            string testUrl = model.TestCreateView!.RecorderStartUrl!;
            string suitName = model.TestCreateView.SuitName!;
            // Compile Valid URL for Driver:
            if (!testUrl.StartsWith("https://"))
            {
                testUrl = testUrl!.Insert(0, "https://");
            }
            // Suit Name Db Lookup => SuitId
            var selectedSuit = _dbContext!.Suits!.Where(s => s.SuitName == suitName).FirstOrDefault();
            // Populate Recorder Model
            var createTest = new RecorderModel
            {
                RecorderWebDriver = model.TestCreateView!.RecorderWebDriver,
                RecorderName = model.TestCreateView.RecorderName,
                RecorderDescription = model.TestCreateView.RecorderDescription,
                SuitId = selectedSuit!.Id
            };
            // Attach,Add & Sync Database
            _dbContext.Recorders!.Add(createTest);
            await _dbContext.SaveChangesAsync();
            // Return Newly Synced Recorder
            return createTest;
        }
    }
}
