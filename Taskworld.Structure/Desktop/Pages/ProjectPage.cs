using OpenQA.Selenium;
using System.Collections.Generic;
using Taskworld.Core.Extensions;
using Taskworld.Core.Models.Constants;

namespace Taskworld.Structure.Desktop.Pages
{
    public class ProjectPage
    {
        private IWebDriver driver;

        public ProjectPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region locators

        private const string CSS_PROJECT_VIEW = ".ax-project-view";
        private const string CSS_NEW_PROJECT = ".ax-new-project-button-box";
        private const string CSS_NEW_PROJECT_POPUP = ".tw-modal__content";
        private const string CSS_NEW_PROJECT_NAME = ".ax-new-project-name-textfield";
        private const string CSS_WORKFLOW_BUTTON = ".ax-new-project-choose-workflow-button";
        private const string CSS_CREATE_PROJECT_BUTTON = ".ax-create-project-button";

        private const string CSS_TASKLIST_NAME = ".ax-new-tasklist-name-textfield";
        private const string CSS_ADD_TASK_BUTTON = ".ax-add-task-button";
        private const string CSS_TASK_DETAIL = ".ax-task-input-panel-textfield";
        private const string CSS_CREATE_TASK = ".ax-create-task-button";
        private const string CSS_TASK_CHECKBOX = ".ax-task-checkbox";
        private const string CSS_TASK_COMPLETE = ".ax-task.--done";
        private const string CSS_TASK_PROPERTY = ".ax-floating-panel-body";

        private const string CSS_OUTSIDE_LAYER = ".ax-click-outside-layer";

        #endregion

        #region elements

        private IWebElement ProjectView => driver.FindElement(By.CssSelector(CSS_PROJECT_VIEW));
        private IWebElement NewProjectButton => driver.FindElement(By.CssSelector(CSS_NEW_PROJECT));
        private IWebElement NewProjectPopup => driver.FindElement(By.CssSelector(CSS_NEW_PROJECT_POPUP));
        private IWebElement NewProjectName => driver.FindElement(By.CssSelector(CSS_NEW_PROJECT_NAME));
        private IWebElement SelectTempleteButton => driver.FindElement(By.CssSelector(CSS_WORKFLOW_BUTTON));
        private IWebElement CreateProjectButton => driver.FindElement(By.CssSelector(CSS_CREATE_PROJECT_BUTTON));
        private IWebElement TaskListName => driver.FindElement(By.CssSelector(CSS_TASKLIST_NAME));
        private IWebElement AddTaskButton => driver.FindElement(By.CssSelector(CSS_ADD_TASK_BUTTON));
        private IWebElement AddTaskDetail => driver.FindElement(By.CssSelector(CSS_TASK_DETAIL));
        private IWebElement CreateTaskButton => driver.FindElement(By.CssSelector(CSS_CREATE_TASK));
        private IList<IWebElement> TaskCheckBox => driver.FindElements(By.CssSelector(CSS_TASK_CHECKBOX));
        private IList<IWebElement> TaskComplete => driver.FindElements(By.CssSelector(CSS_TASK_COMPLETE));
        private IWebElement TaskProperty => driver.FindElement(By.CssSelector(CSS_TASK_PROPERTY));
        private IWebElement OutSideLayer => driver.FindElement(By.CssSelector(CSS_OUTSIDE_LAYER));

        #endregion

        #region actions

        public void CreateNewProject()
        {
            ClickNewProjectButton();
            FillInProjectDetail();
            ClickCreateProjectButton();
        }

        private void ClickNewProjectButton()
        {
            WaitUntilNewProjectButtonDisplay();
            NewProjectButton.Click();
        }

        private void FillInProjectDetail()
        {
            WaitUntilNewProjectPopupDisplay();
            NewProjectName.SendKeys("hello");
            SelectTempleteButton.Click();
        }

        private void ClickCreateProjectButton()
        {
            WaitUntilCreateProjectButtonClickable();
            CreateProjectButton.Click();
            WaitUntilNewProjectPopupNotDisplay();

        }

        public void CreateTaskList()
        {
            WaitUntilTaskListDisplay();
            TaskListName.SendKeys("world");
            TaskListName.SendKeys(Keys.Enter);
        }

        public void CreateTask()
        {
            if (IsOutSideLayerDisplay()) { OutSideLayer.Click(); }
            WaitUntilAddTaskButtonClickable();
            AddTaskButton.Click();
            AddTaskDetail.SendKeys("yo");
            CreateTaskButton.Click();
        }

        public void CompleteFirstTask()
        {
            WaitUntilTasksDisplay();
            TaskCheckBox[0].Click();
        }

        public void ClickFirstCompletedTask()
        {
            WaitUntilCompletedTasksDisplay();
            TaskComplete[0].Click();
        }

        #endregion

        #region display

        public bool IsProjectViewDisplay()
        {
            try { return ProjectView.Displayed; }
            catch { return false; }
        }

        private bool IsNewProjectButtonDisplay()
        {
            try { return NewProjectButton.Displayed; }
            catch { return false; }
        }

        private bool IsNewProjectPopupDisplay()
        {
            try { return NewProjectPopup.Displayed; }
            catch { return false; }
        }

        public bool IsTaskListDisplay()
        {
            try { return TaskListName.Displayed; }
            catch { return false; }
        }

        public bool IsAddTaskButtonDisplay()
        {
            try { return AddTaskButton.Displayed; }
            catch { return false; }
        }

        private bool IsTasksDisplay()
        {
            try { return TaskCheckBox.Count > 0; }
            catch { return false; }
        }

        public bool IsTaskCompleteDisplay()
        {
            try { return TaskComplete.Count > 0; }
            catch { return false; }
        }

        public bool IsTaskPropertyDisplay()
        {
            try { return TaskProperty.Displayed; }
            catch { return false; }
        }

        private bool IsOutSideLayerDisplay()
        {
            try { return OutSideLayer.Displayed; }
            catch { return false; }
        }

        #endregion

        #region wait elements

        public void WaitUntilProjectPageLoad()
        {
            driver.WaitUntil(d => IsProjectViewDisplay(), Time.PAGE_TIMEOUT);
        }

        private void WaitUntilNewProjectButtonDisplay()
        {
            driver.WaitUntil(d => IsNewProjectButtonDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        private void WaitUntilNewProjectPopupDisplay()
        {
            driver.WaitUntil(d => IsNewProjectPopupDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        private void WaitUntilCreateProjectButtonClickable()
        {
            driver.WaitUntilElementIsClickAble(CreateProjectButton, Time.SMALL_COMPONENT_TIMEOUT);
        }

        private void WaitUntilNewProjectPopupNotDisplay()
        {
            driver.WaitUntil(d => !IsNewProjectPopupDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        public void WaitUntilTaskListDisplay()
        {
            driver.WaitUntil(d => IsTaskListDisplay(), Time.COMPONENT_TIMEOUT);
        }

        public void WaitUntilAddTaskButtonDisplay()
        {
            driver.WaitUntil(d => IsAddTaskButtonDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        private void WaitUntilAddTaskButtonClickable()
        {
            driver.WaitUntilElementIsClickAble(AddTaskButton, Time.SMALL_COMPONENT_TIMEOUT);
        }

        private void WaitUntilTasksDisplay()
        {
            driver.WaitUntil(d => IsTasksDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        public void WaitUntilCompletedTasksDisplay()
        {
            driver.WaitUntil(d => IsTaskCompleteDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        public void WaitUntilTaskPropertyDisplay()
        {
            driver.WaitUntil(d => IsTaskPropertyDisplay(), Time.SMALL_COMPONENT_TIMEOUT);
        }

        #endregion
    }
}
