# TaskworldRegressionTest
Regression test for Taskworld's project.

Steps
-
1. User login into system
2. Then, the user creates a project
3. Then, the user creates a tasklist
4. Then, the user creates a task
5. Then, the user complete the task in step 4
6. Then, the user open the completed task to see detail of the task

Solution requirements
-
- NUnit
- Selenium
- .NET Core

Compatibility
-
- Windows
- Mac OS
- UNIX

How to run the test
- 
1. Checkout the repository
2. Restore NuGet packages 
3. Build projects
4. Run test in `Taskworld.Tests` project

NOTE: 

You can change `TestConfiguration.json` to select the environment. This file should be main configuration file in the future.

You can change `URL.json` to change the URL of each environment

You can add or change test account in `UserAccount.json`

Solution Structure
-
This solution contains 3 projects which are

`Taskworld.Core` : To keep driver, models, data provider and execution framework.

`Taskworld.Structure` : To keep locators, elements and methods that related to the pages we do the test.

`Taskworld.Tests` : To keep test scenarios (test cases), test configurations and base test.