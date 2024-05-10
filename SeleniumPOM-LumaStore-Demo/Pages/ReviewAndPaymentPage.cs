using OpenQA.Selenium;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class ReviewAndPaymentPage : BasePage
    {

        public ReviewAndPaymentPage(IWebDriver driver) : base(driver) 
        {
            Wait.Until(d => d.FindElement(By.CssSelector(@".action.primary.checkout")).Enabled);
        }

        public IWebElement PlaceOrderButton => Driver.FindElement(By.CssSelector(@".action.primary.checkout"));

        public OrderSuccessPage PlaceOrderSuccessfully()
        {
            Wait.Until(d => PlaceOrderButton.Enabled);
            PlaceOrderButton.Click();
            return new OrderSuccessPage(Driver);
        }
    }
}