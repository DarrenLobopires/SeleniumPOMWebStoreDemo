using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            UserActions = new Actions(driver);
            NavigationBar = new NavigationBar(driver);
        }
        public string baseUrl => "https://magento.softwaretestingboard.com/";
        public NavigationBar NavigationBar { get; }
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }
        protected Actions UserActions { get; }
    }
}