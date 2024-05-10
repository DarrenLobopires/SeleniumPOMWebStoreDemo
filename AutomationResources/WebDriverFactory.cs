using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch(browserType) 
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException($"No such browser type => {browserType}");

            }
        }
    }
}