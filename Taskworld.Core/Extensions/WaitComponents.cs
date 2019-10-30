using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Taskworld.Core.Extensions
{
    public static class WaitComponents
    {
        public static TResult WaitUntil<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, int second)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(second));
            return wait.UntilCondition(condition, second);
        }

        public static void WaitUntilElementIsClickAble(this IWebDriver driver, IWebElement element, int second)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(second));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static TResult UntilCondition<TResult>(this WebDriverWait driverWait, Func<IWebDriver, TResult> condition, int waitingTime)
        {
            driverWait.Timeout = TimeSpan.FromSeconds(waitingTime);

            try { return driverWait.Until(condition); }
            catch (WebDriverTimeoutException) { return default(TResult); }
        }
    }
}
