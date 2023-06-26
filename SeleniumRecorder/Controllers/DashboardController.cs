using AWAIT.DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumRecorder.DAL;
using SeleniumRecorder.Models;
using System.Diagnostics;
/// BUILT FOR AWAIT - Branden v Staden
/// ->PROTOTYPE VERSION 1: 26/06/23<-
namespace SeleniumRecorder.Controllers
{
    /// <summary>
    /// ALL FRONTEND SERVERSIDE (C#)CODE IMPLEMENTED IN DASHBOARD CONTROLLER
    /// </summary>
    public class DashboardController : Controller
    {
        /// <summary>
        /// NULLABLE OBJECTS
        /// </summary>
        private Task<object>? executeScriptTask;
        private CancellationTokenSource? cancellationTokenSource;
        public ThreadLocal<IWebDriver>? DriverThread;
        public IWebDriver? _webDriver;
        public int _processId = -1;
        /// <summary>
        /// CONSTRUCTOR OBJECTS
        /// </summary>
        private readonly IWebHostEnvironment? _hostEnvironment;
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly AwaitDbContext? _context;
        /// <summary>
        /// CONSTRUCTING...
        /// </summary>
        /// <param name="hostEnvironment"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="context"></param>

        public DashboardController(IWebHostEnvironment? hostEnvironment, IHttpContextAccessor? httpContextAccessor, AwaitDbContext? context)
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        /// <summary>
        /// Responsible for Returning View()[**Dashboard**][Index]
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Responsible for Returning View(model)[ToolBox]
        /// </summary>
        /// <param name="model">SuitTestView</param>
        /// <returns>ToolBox.cshtml</returns>
        public IActionResult ToolBox(SuitTestView model)
        {
            var viewModel = new SuitTestView();
            if (model.ConsoleView != null)
            {
                viewModel.ConsoleView = model.ConsoleView;
            }
            else
            {
                var consoleDefault = new ConsoleViewModel
                {
                    Action = "Reach Potential With Your AWAIT TOOLBOX",
                    Value = "Try Creating a New Test by Registering a Suit and Creating a New Test!\nUse Recorder Controls To Start Testing..."
                };
                viewModel.ConsoleView = consoleDefault;
            }

            var user = _context!.Users!.Where(s => s.UserName!.Equals("JohnDoe")).FirstOrDefault();

            try
            {
                var suits = _context.Suits!.Where(s => s.UserId == user!.Id).Select(s => new SuitView
                {
                    SuitName = s.SuitName,
                    SuitPlan = s.SuitPlan
                }).ToList();

                if (suits.Count() > 0)
                {
                    viewModel.SuitView = suits;
                }
                else
                {
                    var defaultSuit = new List<SuitView>
                {
                    new SuitView
                    {
                        SuitName = "Please Register Suit",
                        SuitPlan = ""
                    }
                };
                    viewModel.SuitView = defaultSuit;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            // Get tests and populate view model
            try
            {
                var suitIds = _context.Suits!.Where(s => s.UserId == user!.Id).Select(s => s.Id).ToList();

                var tests = _context.Tests!
                    .Where(s => suitIds.Contains(s.SuitId))
                    .Select(s => new TestView
                    {
                        TestId = s.Id,
                        TestWebDriver = s.TestWebDriver,
                        TestName = s.TestName,
                        TestType = s.TestType,
                        TestDescription = s.TestDescription,
                        TestUrl = s.TestUrl,
                        SuitId = s.SuitId,
                        SuitName = "Demo Test"
                    })
                    .ToList();

                if (tests.Count() > 0)
                {
                    viewModel.TestView = tests;
                }
                else
                {
                    var defaultTest = new List<TestView>
                    {
                        new TestView
                        {
                            TestWebDriver = "",
                            TestName = "No Tests Created Yet!",
                            TestDescription = "Select/Register Suit and Create New Recorder...",
                            TestUrl = "www.example.com",
                            SuitId = 0,
                            SuitName = ""
                        }
                    };
                    viewModel.TestView = defaultTest;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            return View(viewModel);
        }
        /// <summary>
        /// Responsible for Returning View()[Settings]
        /// </summary>
        /// <returns></returns>
        public IActionResult Settings()
        {
            // Not Implemented
            return View(); // DOES NOT EXISIT YET!
        }
        /// <summary>
        /// Responsible for Generating New Suit Model: Saves to Db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterSuit(SuitTestView model)
        {
            var user = _context!.Users!.FirstOrDefault(s => s.UserName == "JohnDoe");
            var suits = _context.Suits!.Where(s => s.UserId == user!.Id).ToList();
            var registerSuit = new SuitModel
            {
                SuitName = model.SuitRegisterView?.SuitName,
                SuitPlan = model.SuitRegisterView?.SuitPlan,
                UserId = user!.Id
            };

            foreach (var suit in suits)
            {
                if (suit.SuitName == registerSuit.SuitName)
                {
                    // Return a JSON response indicating that the suit name already exists
                    return Json(new { error = "SUIT NAME ALREADY EXISTS" });
                }
            }

            _context.Suits!.Add(registerSuit);
            await _context.SaveChangesAsync();

            // Used to update view
            SuitModel registeredSuit = new()
            {
                SuitName = model.SuitRegisterView?.SuitName,
                SuitPlan = model.SuitRegisterView?.SuitPlan
            };

            return Json(new { suit = registeredSuit });
        }
        /// <summary>
        /// Responsible for Generating New Test Model: Saves to Db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTest(SuitTestView model)
        {
            // Update Console Recorder: Saving Test
            var consoleModel = new ConsoleViewModel
            {
                Action = "save",
                Value = "Saving Test Model..."
            };            

            string testUrl = model.TestCreateView!.TestUrl!;
            string suitName = model.TestCreateView.SuitName!;

            // Compile Valid URL for Driver:
            if (!testUrl.StartsWith("https://"))
            {
                testUrl = testUrl!.Insert(0, "https://");
            }

            // Suit Name Db Lookup => SuitId
            var selectedSuit = _context!.Suits!.Where(s => s.SuitName == suitName).FirstOrDefault();

            var createTest = new TestModel
            {
                TestWebDriver = model.TestCreateView!.TestWebDriver,
                TestName = model.TestCreateView.TestName,
                TestType = model.TestCreateView.TestType,
                TestUrl = testUrl,
                TestDescription = model.TestCreateView.TestDescription,
                SuitId = selectedSuit!.Id
                
            };

            _context.Tests!.Add(createTest);
            await _context.SaveChangesAsync();

            // Update Console Recorder: Saving Test
            consoleModel = new ConsoleViewModel
            {
                Action = $"Successfully Created Test({createTest.TestType}): '{createTest.TestName}'",
                Value = $"Click Start to Navigate to: {createTest.TestUrl}"
            };
            return Json(new { test = consoleModel });
        }
        /// <summary>
        /// Responsible for Playback Functionalities (SeleiumnConstroller)-PASS: DashboardController
        /// </summary>
        /// <param name="testName"></param>
        [HttpGet]
        public void Playback(string? testName)
        {
            // Not Implemented

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
            string webRootPath = _hostEnvironment!.WebRootPath;
            string chromeDriverPath = Path.Combine(webRootPath, "chromeDriver");

            string recordDocumentScriptPATH = Path.Combine(webRootPath, "js", "recorderVersion1.js");
            string recordDocumentScriptCONTENT = System.IO.File.ReadAllText(recordDocumentScriptPATH);

            // Setup Web Driver & Process
            var cService = ChromeDriverService.CreateDefaultService(chromeDriverPath);
            var options = new ChromeOptions();
            _webDriver = new ChromeDriver(cService, options);
            // Navigate to URL
            if (url != null)
            {
                _webDriver.Navigate().GoToUrl(url);
                _webDriver.Manage().Window.Maximize();
            }

            // Get the Process ID
            var pid = cService.ProcessId;
            const string cookieName = "web-driver-pid";
            var requestCookies = _httpContextAccessor!.HttpContext!.Request.Cookies;
            string? initialRequest = requestCookies[cookieName];
            if(!String.IsNullOrEmpty(initialRequest))
            {
                Console.WriteLine($"COOKIE DETECTED: {initialRequest}");
            }
            else
            {
                Console.WriteLine($"{initialRequest} - NULL COOKIE REFERENCE");

            }
            // Create/Update Cookie WebDriver PID
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                IsEssential = true

            };
            _httpContextAccessor.HttpContext!.Response.Cookies
                        .Append(cookieName, pid.ToString(), cookieOptions);

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
        public void Recorder([FromBody] dynamic eventResult)
        {
            var webJSON = JsonConvert.DeserializeObject<JSONModel>(eventResult.ToString());
            Console.WriteLine($"{webJSON}");
        }
        /// <summary>
        /// Responsible for Deleting Recorder Models
        /// </summary>
        /// <param name="recorderId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RecorderDelete(int recorderId)
        {
            var recorder = _context!.Tests!.Where(s => s.Id == recorderId).FirstOrDefault();
            _context.Tests!.Remove(recorder!);
            _context.SaveChanges();
            return RedirectToAction(nameof(ToolBox));
        }
        /// <summary>
        /// Responsible for Monitoring URL Changes
        /// </summary>
        /// <param name="initialUrl"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task MonitorUrlChanges(string initialUrl, CancellationToken cancellationToken)
        {
            string webRootPath = _hostEnvironment!.WebRootPath;
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
        /// <summary>S
        /// Responsible for Disposing WebDriver & Preventing Memory Leaks
        /// [!!NOT WORKING!!]
        /// </summary>
        [HttpPost]
        public IActionResult StopRecorder()
        {
            const string cookieName = "web-driver-pid";
            var requestCookies = _httpContextAccessor!.HttpContext!.Request.Cookies;
            string? initialRequest = requestCookies[cookieName];
            if (!String.IsNullOrEmpty(initialRequest))
            {
                Console.WriteLine($"INITIAL COOKIE DETECTED: {initialRequest}");
                // Parse the PID from the cookie value
                int pid = int.Parse(initialRequest!);

                // Get the process using the stored PID
                Process process = Process.GetProcessById(pid);

                // Kill the process
                process.Kill();
                return new JsonResult(process.ExitCode);
            }
            else
            {
                Console.WriteLine($"{initialRequest} - NULL COOKIE REFERENCE");
            }
            return BadRequest();
        }
    }
}