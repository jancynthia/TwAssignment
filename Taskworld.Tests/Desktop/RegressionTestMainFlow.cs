using NUnit.Framework;
using Taskworld.Core;
using Taskworld.Structure.Desktop.Pages;
using Taskworld.Core.Models.Constants;

namespace Taskworld.Tests.Desktop
{
    [TestFixture]
    public class RegressionTestMainFlow : BaseTest
    {
        private LoginPage loginPage;
        private ProjectPage projectPage;

        [SetUp]
        public void SetUp()
        {
            this.driver = DriverFactory.CreateWebDriver(BrowserType.Chrome);
            loginPage = new LoginPage(driver);
            projectPage = new ProjectPage(driver);
        }

        [Test]
        public void VerifyMainFlow()
        {
            var account = UserAccountProvider.GetUserAccount(UserAccountType.NormalUser);

            // land to home page and redirect to login page
            driver.Url = URLProvider.GetURL(environment, PageURL.HomePage);
            loginPage.WaitUntilLoginPageLoad();
            Assert.True(loginPage.IsLoginLayoutDisplay(), ErrorMessages.INCORRECT_LOGIN_PAGE);

            // do login with selected server
            loginPage.DoLogin(account);

            // wait dashboard page
            projectPage.WaitUntilProjectPageLoad();
            Assert.True(projectPage.IsProjectViewDisplay(), ErrorMessages.INCORRECT_PROJECT_PAGE);

            // create project
            projectPage.CreateNewProject();
            projectPage.WaitUntilTaskListDisplay();
            Assert.True(projectPage.IsTaskListDisplay(), ErrorMessages.NO_TASK_LIST);

            // create tasklist
            projectPage.CreateTaskList();

            // create task
            projectPage.CreateTask();
            projectPage.WaitUntilAddTaskButtonDisplay();
            Assert.True(projectPage.IsAddTaskButtonDisplay(), ErrorMessages.CANNOT_ADD_TASK_LIST);

            // complete tast
            projectPage.CompleteFirstTask();
            projectPage.WaitUntilCompletedTasksDisplay();
            Assert.True(projectPage.IsTaskCompleteDisplay(), ErrorMessages.NO_COMPLETED_TASK);

            // click complete tast to see detail
            projectPage.ClickFirstCompletedTask();
            projectPage.WaitUntilTaskPropertyDisplay();
            Assert.True(projectPage.IsTaskPropertyDisplay(), ErrorMessages.NO_TASK_PROPERTY);
        }
    }
}
