using OpenQA.Selenium;
using System;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class OrderSuccessPage : BasePage
    {
        public OrderSuccessPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(d => d.Url.Contains("success"));
            Wait.Until(d => d.FindElement(By.CssSelector(@".action.primary.continue")).Enabled);
        }

        public string OrderNumber => Driver.FindElement(By.CssSelector(@".checkout-success p span")).Text;
    }
}

