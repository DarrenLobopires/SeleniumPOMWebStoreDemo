using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class BaseComponent
    {
        public BaseComponent(IWebDriver driver) 
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            UserActions = new Actions(driver);
        }

        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }
        protected Actions UserActions { get; }
    }
}