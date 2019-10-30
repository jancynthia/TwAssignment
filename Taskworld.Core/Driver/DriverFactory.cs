using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Taskworld.Core
{
    public static class DriverFactory
    {
        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch(browserType)
            {
                case BrowserType.Chrome: return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                case BrowserType.FireFox: // TODO
                default: return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
        }
    }
}
