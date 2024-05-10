using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class ProductGrid : BasePage
    {
        // Container Object for Product Square objects
        // Exposes actions for accessing one or more product squares 
        // Several pages contain a Product Grid, including Home Page (hot sellers) and Search Results Page
        public ProductGrid(IWebDriver driver) : base(driver) {}

        private ReadOnlyCollection<IWebElement> ProductSquareElements => Driver.FindElements(By.CssSelector(".products-grid .product-item"));
        public int ProductCount => ProductSquareElements.Count();


        // Matches and returns first matching product square element
        public ProductSquare GetFirstProductOnPage()
        {
            return GetAllProducts()[0];
        }

        // Creates and returns a new list of ProductSquare objects
        public List<ProductSquare> GetAllProducts()
        {
            List<ProductSquare> productSquares = new List<ProductSquare>();
            // Product Elements transformed to Product Objects. Product Objects stored into a new List 
            productSquares = ProductSquareElements.Select(prodEle => new ProductSquare(prodEle, Driver)).ToList();
            return productSquares;
        }

        public List<ProductSquare> GetAllMatchingProducts(Predicate<ProductSquare> match)
        {
            List<ProductSquare> matchedProduct = GetAllProducts().FindAll(match);
            return matchedProduct;
        }

        public ProductSquare GetFirstMatchingProducts(Func<ProductSquare, bool> match)
        {
            ProductSquare matchedProduct = GetAllProducts().First(match);
            return matchedProduct;
        }
    }
}