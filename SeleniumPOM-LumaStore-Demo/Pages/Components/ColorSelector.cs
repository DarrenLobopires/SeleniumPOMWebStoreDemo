using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class PPColorSelector : BaseComponent
    {

        private By colorsLocator = By.CssSelector(@".swatch-option.color");


        // Constructor sets product root to speciifiy which product on page we are accessing Color Selector for
        public PPColorSelector(IWebDriver driver) : base(driver) {}
        
        private IList<IWebElement> ColorElements => Driver.FindElements(colorsLocator);


        // Click the first color in the Colors list
        public void ClickFirstColor()
        {
            ColorElements.First().Click();
        }

        // Click the last color in the color
        public void ClickLastColor()
        {
            int lastIndex = ColorElements.Count - 1;
            ColorElements[lastIndex].Click();
        }


        // Returns Delegate which checks if the color list has loaded (i.e., list of elements > 0)
        public Func<IWebDriver, bool> ColorsLoaded()
        {
            return (d) => d.FindElements(colorsLocator).Any();
        }



    }
}