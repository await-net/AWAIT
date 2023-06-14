using OpenQA.Selenium;

namespace SeleniumRecorder.Services
{
    public class DisposeWebDriver : IDisposable
    {
        public IWebDriver? _webDriver;
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _webDriver!.Quit();
                    _webDriver.Dispose();
                }

                disposed = true;
            }
        }

        // Force the Driver to Dispose
        ~DisposeWebDriver()
        {
            Dispose(false);
        }
    }
}
