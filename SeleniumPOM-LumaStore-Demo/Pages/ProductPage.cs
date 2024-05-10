using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class ProductPage : BasePage
    {
        // Fields
        private readonly string productUrl="";
        private readonly By sizeErrorMessageLocator = By.XPath(@"//*[@id='super_attribute[143]-error']");
        private readonly By colorErrorMessageLocator = By.XPath(@"//*[@id='super_attribute[93]-error']");
        private readonly By addToCartButtonLocator = By.Id("product-addtocart-button");


        public ProductPage(IWebDriver driver) : base(driver) 
        {
            ColorSelector = new PPColorSelector(driver);
            SizeSelector = new PPSizeSelector(driver);
            PPQuantityField = new PPQuantityField(driver);
            // Constructor waits when navigating from another page within the site
            if (driver.Url.Contains(baseUrl))
            {
                Wait.Until(ColorSelector.ColorsLoaded());
            }
        }


        public PPColorSelector ColorSelector { get; }
        public PPSizeSelector SizeSelector { get; }
        internal PPQuantityField PPQuantityField{ get; }



        // Properties
        private IWebElement ColorErrorElement => Driver.FindElement(colorErrorMessageLocator);
        private IWebElement SizeErrorElement => Driver.FindElement(sizeErrorMessageLocator);
        private IWebElement AddToCartButton => Driver.FindElement(addToCartButtonLocator);


        // Methods
        // Navigate to page 
        public ProductPage GoToPage(string product)
        {
            string productUrl = CreateProductUrl(product);
            Driver.Navigate().GoToUrl( baseUrl + productUrl );
            Wait.Until(ColorSelector.ColorsLoaded());
            return this;
        }


        // Clicks the Add to Cart Button
        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }

        // Helper Functions
        // Creates product url from product name
        private string CreateProductUrl(string product)
        {
            // Replace white space in product name with "-" and concat ".html"
            return product.Replace(" ", "-") + ".html";
        }

        // Return the text (error message) in the error message element
        public string CheckColorErrorMessage()
        {
            Wait.Until(ErrorMessageDisplayed(ColorErrorElement));
            return ColorErrorElement.Text;
        }

        // Return the text (error message) in the error message element
        public string CheckSizeErrorMessage()
        {
            Wait.Until(ErrorMessageDisplayed(SizeErrorElement));
            return SizeErrorElement.Text;
        }

        // Returns Delegate which checks if errormessage element contains text
        private Func<IWebDriver, bool> ErrorMessageDisplayed(IWebElement element)
        {
            return (d) => string.IsNullOrWhiteSpace(element.Text) ? false : true;
        }

    }
}