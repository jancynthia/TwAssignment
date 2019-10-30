using NUnit.Framework;
using OpenQA.Selenium;
using Taskworld.Core;

namespace Taskworld.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string environment = TestConfigurationProvider.GetEnvironment();

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
