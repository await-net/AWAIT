using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumRecorder.Controllers
{
    public class SeleniumController : Controller
    {
      
        public IActionResult Index(int id)
        {
            //var seleniumTest = JsonConvert.DeserializeObject<EventTargetModel>(System.IO.File.ReadAllText("IDR.side"));
            //var test = seleniumTest.Tests.FirstOrDefault();
            //var url = seleniumTest.Url;

            //var chromeOptions = new ChromeOptions {

            //};
            //var driver = new ChromeDriver();
            //driver.Manage().Timeouts().PageLoad = new TimeSpan(0,0,0,15);

            //driver.Navigate().GoToUrl(url);
            //foreach(var command in test.Commands)
            //{ 
            //    try
            //    {
            //        IWebElement element = null;
            //        switch (command.Comm)
            //        { 
            //          case "setWindowSize":
            //                driver.Manage().Window.Maximize();
            //                break;
            //            case "type":
            //                element = GetElement(command.Target,driver,TimeSpan.FromMinutes(1));
            //                element.SendKeys(command.Value);
            //                break;

            //            case "click":
            //                element = driver.FindElement(By.CssSelector(command.Target.Replace("css=","")));
            //                Actions action = new Actions(driver);
            //                action.Click(element);
            //                action.Build().Perform();

            //                break;

            //            case "pause":
            //                Thread.Sleep(int.Parse(command.Target));
            //                break;
            //    }

            //    }
            //    catch (NoSuchElementException) { }
            //    {

            //    }
            //}
            //driver.Close();
            //driver.Dispose();
            //return Content("Your Test has Passed");
            return View();
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
