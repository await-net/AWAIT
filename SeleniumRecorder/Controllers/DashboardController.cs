using AWAIT.DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumRecorder.Models;
using SeleniumRecorderApi.Data;
using System.Diagnostics;

namespace SeleniumRecorder.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AwaitDbContext _context;

        private Task<object>? executeScriptTask;
        private CancellationTokenSource? cancellationTokenSource;
        public ThreadLocal<IWebDriver> DriverThread;
        public IWebDriver? _webDriver;
        public int _processId = -1;

        public DashboardController(IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor, AwaitDbContext context)
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ToolBox()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTest(TestSuitViewModel testSuitView)
        {
            var suitModel = new SuitModel
            {
                SuitName = testSuitView.Suit!.SuitName,
                SuitPlan = testSuitView.Suit.SuitPlan
            };
            var testModel = new TestModel
            {
                TestWebDriver = testSuitView.Test!.TestWebDriver,
                TestName = testSuitView.Test.TestName,
                TestType = testSuitView.Test.TestType,
                TestUrl = testSuitView.Test.TestUrl,
                SuitId = suitModel.SuitId,
                Suit = suitModel
            };
            await _context.Suits.AddAsync(suitModel);
            await _context.SaveChangesAsync();
            await _context.Tests.AddAsync(testModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Recorder), new { url = testSuitView.Test.TestUrl});
        }
        [HttpGet]
        public async Task Playback()
        {
            Console.WriteLine("PLAYBACK!");
            SeleniumController selenium = new();
            selenium.IndexAsync(1);
            ViewBag.Console = "Started IDR Login Playback";

        }
        /// <summary>
        /// Responsible for Starting Recorder Script Files & Relevant Monitoring Systems
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpGet]
        public async Task Recorder(string? url, TestSuitViewModel testSuitModel)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            string chromeDriverPath = Path.Combine(webRootPath, "chromeDriver");

            string recordDocumentScriptPATH = Path.Combine(webRootPath, "js", "recorderVersion1.js");
            string recordDocumentScriptCONTENT = System.IO.File.ReadAllText(recordDocumentScriptPATH);

            // Setup Web Driver & Process
            var cService = ChromeDriverService.CreateDefaultService(chromeDriverPath);
            var options = new ChromeOptions();
            _webDriver = new ChromeDriver(cService, options);
            Console.WriteLine($"{cService.ProcessId}");
            // Navigate to URL
            if (url != null)
            {
                _webDriver.Navigate().GoToUrl(url);
                _webDriver.Manage().Window.Maximize();
            }

            // Get the Process ID
            int pid = cService.ProcessId;

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_webDriver;
            // Maximum wait time for the script execution
            TimeSpan timeout = TimeSpan.FromSeconds(10);
            // Execute the script asynchronously
            executeScriptTask = Task.Run(() =>
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_webDriver;
                var eventResult = jsExecutor.ExecuteScript(recordDocumentScriptCONTENT);
                return eventResult; // Return the captured event and element information
            });

            // Create a cancellation token source for monitoring URL changes
            cancellationTokenSource = new CancellationTokenSource();

            // Start monitoring the URL in a separate task
            Task monitorUrlTask = MonitorUrlChanges(url!, cancellationTokenSource.Token);

            // Wait for the script execution to complete or timeout
            WebDriverWait wait = new(_webDriver, timeout);
            try
            {
                await wait.Until(d => executeScriptTask);
            }
            catch (WebDriverTimeoutException)
            {
                // Handle the timeout exception
                Console.WriteLine("ERROR: Script execution timed out.");
            }
            await monitorUrlTask;
            cancellationTokenSource.Cancel();
        }       
        /// <summary>
        /// Responsible for Capturing Events & Saving back to database
        /// </summary>
        /// <param name="eventResult"></param>
        /// <returns></returns>
        [EnableCors]
        [HttpPost]
        public async Task Recorder([FromBody] dynamic eventResult)
        {
            var webJSON = JsonConvert.DeserializeObject<JSONModel>(eventResult.ToString());
            Console.WriteLine($"{webJSON}");
        }
        /// <summary>
        /// Responsible for Monitoring URL Changes
        /// </summary>
        /// <param name="initialUrl"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task MonitorUrlChanges(string initialUrl, CancellationToken cancellationToken)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            string chromeDriverPath = Path.Combine(webRootPath, "chromeDriver");

            string recordDocumentScriptPATH = Path.Combine(webRootPath, "js", "recorderVersion1.js");
            string recordDocumentScriptCONTENT = System.IO.File.ReadAllText(recordDocumentScriptPATH);

            while (!cancellationToken.IsCancellationRequested)
            {
                // Check if the URL has changed
                if (_webDriver!.Url != initialUrl)
                {
                    // Create a new executeScriptTask for the new URL
                    executeScriptTask = Task.Run(() =>
                    {
                        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_webDriver;
                        var eventResult = jsExecutor.ExecuteScript(recordDocumentScriptCONTENT);
                        return eventResult; // Return the captured event and element information
                    });

                    // Update the initialUrl to the new URL
                    initialUrl = _webDriver.Url;
                }

                // Delay for a certain period before checking the URL again
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
        /// <summary>
        /// Responsible for Disposing WebDriver & Preventing Memory Leaks
        /// </summary>
        [HttpGet]
        public IActionResult StopRecorder()
        {
            // Retrieve the cookie
            if (Request.Cookies.TryGetValue("WebDriverPID", out string? cookieValue))
            {
                // Parse the PID from the cookie value
                int pid = int.Parse(cookieValue!);

                // Get the process using the stored PID
                Process process = Process.GetProcessById(pid);

                // Kill the process
                process.Kill();
                Console.WriteLine(cookieValue);

                return Ok();
            }
            else
            {
                Console.WriteLine("Cookie Not Found!");
            }
            return BadRequest();
        }
    }
}