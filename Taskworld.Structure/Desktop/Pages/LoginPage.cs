using OpenQA.Selenium;
using Taskworld.Core.Extensions;
using Taskworld.Core.Models.Constants;
using Taskworld.Core;
using System.Collections.Generic;

namespace Taskworld.Structure.Desktop.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region locators

        private const string CSS_LOGIN_PAGE = ".tw-login-layout";
        private const string CSS_SERVER = ".ax-server-selection__dropdown";
        private const string CSS_SERVER_LIST = ".tw-click-area.tw-menu__item";
        private const string CSS_LOGIN_FORM = ".tw-login-form-container__stack";
        private const string CSS_INPUT_USERNAME = ".ax-login-form__email-field";
        private const string CSS_INPUT_PASSWORD = ".ax-login-form__password-field";
        private const string CSS_LOGIN_BUTTON = ".ax-login-form__login-button";

        #endregion

        #region elements

        private IWebElement LoginLayout => driver.FindElement(By.CssSelector(CSS_LOGIN_PAGE));
        private IWebElement ServerName => driver.FindElement(By.CssSelector(CSS_SERVER));
        private IList<IWebElement> ServerList => driver.FindElements(By.CssSelector(CSS_SERVER_LIST));
        private IWebElement LoginForm => driver.FindElement(By.CssSelector(CSS_LOGIN_FORM));
        private IWebElement LoginUsername => driver.FindElement(By.CssSelector(CSS_INPUT_USERNAME));
        private IWebElement LoginPassword => driver.FindElement(By.CssSelector(CSS_INPUT_PASSWORD));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector(CSS_LOGIN_BUTTON));
        
        #endregion

        #region actions

        private void SelectServer(int env)
        {
            WaitUntilLoginFormDisplay();
            ClickServer();
            SelectServerInList(env); 
        }

        private void ClickServer()
        {
            WaitUntilServerNameDisplay();
            ServerName.Click();
        }

        private void SelectServerInList(int env)
        {
            WaitUntilServerListDisplay();
            ServerList[env].Click();
            WaitUntilServerListNotDisplay();
        }

        public void DoLogin(UserAccount account)
        {
            WaitUntilLoginFormDisplay();
            SelectServer(account.UserServer);
            WaitUntilLoginFormDisplay();
            FillUsername(account.Username);
            FillPassword(account.Password);
            ClickLoginButton();
        }

        private void FillUsername(string username)
        {
            LoginUsername.SendKeys(username);
        }

        private void FillPassword(string password)
        {
            LoginPassword.SendKeys(password);
        }

        private void ClickLoginButton()
        {
            LoginButton.Click();
        }

        #endregion

        #region display

        public bool IsLoginLayoutDisplay()
        {
            try { return LoginLayout.Displayed; }
            catch { return false; }
        }

        private bool IsServerDisplay()
        {
            try { return ServerName.Displayed; }
            catch { return false; }
        }

        private bool IsServerListDisplay()
        {
            try { return ServerList.Count > 0; }
            catch { return false; }
        }

        private bool IsLoginFormDisplay()
        {
            try { return LoginForm.Displayed; }
            catch { return false; }
        }

        #endregion

        #region wait elements

        public void WaitUntilLoginPageLoad()
        {
            driver.WaitUntil(d => IsLoginLayoutDisplay(), Time.PAGE_TIMEOUT);
        }

        public void WaitUntilServerNameDisplay()
        {
            driver.WaitUntil(d => IsServerDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        public void WaitUntilServerListDisplay()
        {
            driver.WaitUntil(d => IsServerListDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        public void WaitUntilServerListNotDisplay()
        {
            driver.WaitUntil(d => !IsServerListDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        public void WaitUntilLoginFormDisplay()
        {
            driver.WaitUntil(d => IsLoginFormDisplay(), Time.COMPONENT_TIMEOUT);
        }
        
        #endregion
    }
}
