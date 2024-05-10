using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class ShippingPage : BasePage
    {


        public ShippingPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(d => d.FindElement(By.CssSelector(@"input[name='ko_unique_1']")).Enabled);
        }
        public IWebElement EmailField => Driver.FindElement(By.CssSelector("#customer-email-fieldset #customer-email"));
        public IWebElement FirstNameField => Driver.FindElement(By.CssSelector(@"input[name='firstname']"));
        public IWebElement LastNameField => Driver.FindElement(By.CssSelector(@"input[name='lastname']"));
        public IWebElement PhoneField => Driver.FindElement(By.CssSelector(@"input[name='telephone']"));

        public IWebElement StreetAddressField => Driver.FindElement(By.CssSelector(@"input[name='street[0]']"));
        public IWebElement CityField => Driver.FindElement(By.CssSelector(@"input[name='city']"));
        public SelectElement CountrySelect => new SelectElement(Driver.FindElement(By.CssSelector(@"select[name='country_id']")));
        public SelectElement RegionSelect => new SelectElement(Driver.FindElement(By.CssSelector(@"select[name='region_id']")));
        public IWebElement PostalField => Driver.FindElement(By.CssSelector(@"input[name='postcode']"));

        public IWebElement NextButton => Driver.FindElement(By.CssSelector(".button.action.continue.primary"));

        public void FillOutShopperAddressFields(string street, string city, string country, string region, string postal)
        {
            StreetAddressField.SendKeys(street);
            CityField.SendKeys(city);
            CountrySelect.SelectByText(country);
            // ko_unique_x where x increments each time the shipping method updates
            Wait.Until(d => !d.FindElement(By.CssSelector(@"input[name*='ko_unique']")).Enabled);
            Wait.Until(d => d.FindElement(By.CssSelector(@"input[name*='ko_unique']")).Enabled); // Wait until name containing "ko_unique" is enabled
            RegionSelect.SelectByText(region);
            PostalField.SendKeys(postal);
        }

        public void FillOutShopperInfoFields(string fn, string ln, string email, string phone)
        {
            EmailField.SendKeys(email);
            FirstNameField.SendKeys(fn);
            LastNameField.SendKeys(ln);
            PhoneField.SendKeys(phone);
        }

        public ReviewAndPaymentPage ClickNextWithValidFields()
        {
            NextButton.Click();
            return new ReviewAndPaymentPage(Driver);
        }
    }
}