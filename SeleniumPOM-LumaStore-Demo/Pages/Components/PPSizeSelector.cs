using OpenQA.Selenium;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class PPSizeSelector : BasePage
    {
        private By errorMessageLocator = By.XPath(@"//*[@id='super_attribute[143]-error']");

        // Constructor sets product root to speciifiy which product on page we are accessing Color Selector for
        public PPSizeSelector(IWebDriver driver) : base(driver) {}


        private IWebElement SizeErrorElement => Driver.FindElement(errorMessageLocator);
        private IWebElement XsButtonElement => Driver.FindElement(By.CssSelector("[option-label='XS']"));
        private IWebElement SButtonElement => Driver.FindElement(By.CssSelector("[option-label='S']"));
        private IWebElement MButtonElement => Driver.FindElement(By.CssSelector("[option-label='M']"));
        private IWebElement LButtonElement => Driver.FindElement(By.CssSelector("[option-label='L']"));
        private IWebElement XLButtonElement => Driver.FindElement(By.CssSelector("[option-label='XL']"));



        public void ClickLargeSize()
        {
            LButtonElement.Click();
        }

        // Returns Delegate which checks if errormessage element contains text
        private Func<IWebDriver, bool> IsErrorMessageDisplayed()
        {
            return (d) => string.IsNullOrWhiteSpace(SizeErrorElement.Text) ? false : true;
        }
    }
}