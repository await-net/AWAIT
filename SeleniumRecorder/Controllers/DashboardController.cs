using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumRecorder.DAL;
using SeleniumRecorder.Models;
using SeleniumRecorder.Services;
using System;
using System.Text.Json;

namespace SeleniumRecorder.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AwaitDbContext _context;

        private Task<object>? executeScriptTask;
        private CancellationTokenSource? cancellationTokenSource;
        public IWebDriver? webDriver;

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
        [HttpGet]
        public async Task Playback()
        {
            Console.WriteLine("PLAYBACK!");
            SeleniumController selenium = new();
            selenium.Index(1);
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
        public async Task Recorder(string? url)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            string chromeDriverPath = Path.Combine(webRootPath, "chromeDriver");

            string recordDocumentScriptPATH = Path.Combine(webRootPath, "js", "recorderVersion1.js");
            string recordDocumentScriptCONTENT = System.IO.File.ReadAllText(recordDocumentScriptPATH);

            // Ensure WebDriver Exists
            ChromeOptions chromeOptions = new();
            webDriver ??= new ChromeDriver(chromeDriverPath, chromeOptions);

            // Initialize Driver if stop is FALSE
            if (url != null)
            {
                webDriver.Navigate().GoToUrl(url);
                webDriver.Manage().Window.Maximize();
            }

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)webDriver;
            // Maximum wait time for the script execution
            TimeSpan timeout = TimeSpan.FromSeconds(10);

            // Execute the script asynchronously
            executeScriptTask = Task.Run(() =>
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)webDriver;
                var eventResult = jsExecutor.ExecuteScript(recordDocumentScriptCONTENT);
                return eventResult; // Return the captured event and element information
            });

            // Create a cancellation token source for monitoring URL changes
            cancellationTokenSource = new CancellationTokenSource();

            // Start monitoring the URL in a separate task
            Task monitorUrlTask = MonitorUrlChanges(url!, cancellationTokenSource.Token);

            // Wait for the script execution to complete or timeout
            WebDriverWait wait = new(webDriver, timeout);
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
            // Deserialize the JSON string
            try
            {
                Console.WriteLine($"Recording {eventResult.ToString()}");
                // Deserialize the JSON string
                var json = JsonConvert.DeserializeObject<dynamic>(eventResult.ToString());
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
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
                if (webDriver!.Url != initialUrl)
                {
                    // Create a new executeScriptTask for the new URL
                    executeScriptTask = Task.Run(() =>
                    {
                        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)webDriver;
                        var eventResult = jsExecutor.ExecuteScript(recordDocumentScriptCONTENT);
                        return eventResult; // Return the captured event and element information
                    });

                    // Update the initialUrl to the new URL
                    initialUrl = webDriver.Url;
                }

                // Delay for a certain period before checking the URL again
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
        /// <summary>
        /// Responsible for Disposing WebDriver & Preventing Memory Leaks
        /// </summary>
        [HttpGet]
        private void DisposeWebDriver()
        {
            webDriver!.Dispose();
            // Garbage Collection Every Monday!
            DisposeWebDriver dispose = new();
            dispose.Dispose();

        }
    }
}