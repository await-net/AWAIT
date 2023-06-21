using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumRecorderApi.Data;
using SeleniumRecorderApi.Interfaces;
using SeleniumRecorderApi.Repositories;

namespace SeleniumRecorder.Controllers
{
    public class SeleniumController : Controller
    {
        private readonly AwaitDbContext _context;
        public IWebDriver? _webDriver;
        public IDBRepository _dbRepository;

        public SeleniumController(IDBRepository dBRepository, IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor, AwaitDbContext context)
        {
            _context = context;
            this._dbRepository = dBRepository;
        }

        public SeleniumController() { }

        public async Task<IActionResult> IndexAsync(int id)
        {

            var suite = await _dbRepository.GetTestSuite(id);
            var tests = await _dbRepository.GetTests(suite.SuitId);
            var test = tests.FirstOrDefault();
           
            var events = _context.EPTs.Where(x => x.Id == test.TestId);
            _webDriver.Navigate().GoToUrl(test?.TestUrl);
            foreach (var command in events)
            {
                try
                {
                    IWebElement element = null;
                    switch (command.EventTarget.EventType)
                    {
                        case "setWindowSize":
                            _webDriver.Manage().Window.Maximize();
                            break;
                        case "type":
                            var emailCode = "";
                            element = GetElement(command.EventTarget.TargetEvent.Targets.FirstOrDefault().Type, _webDriver, TimeSpan.FromMinutes(1));
                            if (command.EventTarget.EventType.Contains("Code"))
                            {
                                var mailRepository = new MailRepository("imap.gmail.com", 993, true, "tmartin804@gmail.com", "BuggeryScott");
                                var email = mailRepository.GetAllMails().LastOrDefault();
                                emailCode = email.Split(" ").Where(x => int.TryParse(x, out var code)).Select(x => x).FirstOrDefault();
                            }
                            element.SendKeys(string.IsNullOrWhiteSpace(emailCode) ? emailCode : "");
                            break;

                        case "click":
                            element = GetElement(command.TargetModel.ByXPath, _webDriver, TimeSpan.FromMinutes(1));
                            Actions action = new Actions(_webDriver);
                            action.Click(element);
                            action.Build().Perform();
                            break;

                        case "pause":
                            Thread.Sleep(2000);
                            break;
                    }

                }

                catch (NoSuchElementException) { }
                {

                }
            }
            _webDriver.Close();
            _webDriver.Dispose();
            return Content("Your Test has Passed");
        }

        private List<IWebElement> GetElements(By by,IWebDriver driver,TimeSpan timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                var elements = wait.Until<List<IWebElement>>(drv => drv.FindElements(by).ToList());
                return elements;
            }
            catch (TimeoutException) { return null; }
        }

        private IWebElement GetElement(string target, IWebDriver driver, TimeSpan timeout)
        {
            try
            {
                By by = null;
                //var targets = new[];
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                var element = wait.Until(drv => drv.FindElement(by));
                return element;
            }
            catch (TimeoutException) { return null; }
        }
    }
}
