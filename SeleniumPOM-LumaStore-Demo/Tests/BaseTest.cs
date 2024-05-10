using AutomationResources;
using OpenQA.Selenium;

namespace SeleniumPOM_LumaStore_Demo.Tests
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [TestInitialize]
        public void SetupBeforeEveryTest()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void CleanupAfterEveryTest() 
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}