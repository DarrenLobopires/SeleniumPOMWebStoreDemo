using OpenQA.Selenium;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class SizeSelector : BasePage
    {
        private IWebElement productRoot;
        private By errorMessageLocator = By.XPath(@"//*[@id='super_attribute[143]-error']");

        // Constructor sets product root to speciifiy which product on page we are accessing Color Selector for
        public SizeSelector(IWebDriver driver) : base(driver)
        {
            productRoot = Driver.FindElement(By.TagName("body"));

        }
        // Constructor sets product root to speciifiy which product on page we are accessing Size Selector for
        public SizeSelector(IWebDriver driver, IWebElement productRoot) : base(driver) 
        {
            this.productRoot = productRoot;
        }

        private IWebElement SizeErrorElement => productRoot.FindElement(errorMessageLocator);
        private IWebElement XsButtonElement => productRoot.FindElement(By.CssSelector("[option-label='XS']"));
        private IWebElement SButtonElement => productRoot.FindElement(By.CssSelector("[option-label='S']"));
        private IWebElement MButtonElement => productRoot.FindElement(By.CssSelector("[option-label='M']"));
        private IWebElement LButtonElement => productRoot.FindElement(By.CssSelector("[option-label='L']"));
        private IWebElement XLButtonElement => productRoot.FindElement(By.CssSelector("[option-label='XL']"));



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