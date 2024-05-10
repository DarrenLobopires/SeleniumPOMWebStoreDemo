using OpenQA.Selenium;
using SeleniumPOM_LumaStore_Demo.Pages;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) 
        {
            ProductGrid = new ProductGrid(Driver);
            // Constructor waits when navigating from another page within the site
            if (driver.Url.Contains(baseUrl))
            {
                Wait.Until(ProductGrid.GetFirstProductOnPage().ColorSelector.ColorsLoaded());
            }
        }
        public ProductGrid ProductGrid { get; }
        

        public HomePage GoToPage()
        {
            Driver.Navigate().GoToUrl(baseUrl);
            Wait.Until(ProductGrid.GetFirstProductOnPage().ColorSelector.ColorsLoaded());
          
            return this;
        }
    }
}