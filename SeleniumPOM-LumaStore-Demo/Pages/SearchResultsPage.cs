using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class SearchResultsPage : BasePage
    {
        private string searchUrl = "https://magento.softwaretestingboard.com/catalogsearch/result/?q=";


        public SearchResultsPage(IWebDriver driver) : base(driver) 
        {
            ProductGrid = new ProductGrid(Driver);
            // Constructor waits when navigating from another page within the site
            if (driver.Url.Contains(baseUrl))
            {
                Wait.Until(ProductGrid.GetFirstProductOnPage().ColorSelector.ColorsLoaded());
            }
        }

        public ProductGrid ProductGrid { get; }

        public SearchResultsPage GoToPage(string searchQuery)
        {
            Driver.Navigate().GoToUrl(searchUrl + searchQuery);
            Wait.Until(ProductGrid.GetFirstProductOnPage().ColorSelector.ColorsLoaded());

            return this;
        }
    }
}