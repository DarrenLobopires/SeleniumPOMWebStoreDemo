using OpenQA.Selenium;
using SeleniumPOM_LumaStore_Demo.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    // ProductSquare is the object representation of the web elements containing product properties and actions
    public class ProductSquare : BaseComponent
    {
        private IWebElement productRoot;
        private readonly By productNameLocator = By.CssSelector(".product-item-name");
        private readonly By productPriceLocator = By.ClassName("price");
        private readonly By addToCartLocator = By.CssSelector(".action.tocart.primary");
        

        public ProductSquare(IWebElement productRoot, IWebDriver driver) : base (driver) 
        {
            this.productRoot = productRoot;
            ColorSelector = new ColorSelector(Driver, this.productRoot);
            SizeSelector = new SizeSelector(Driver, this.productRoot);
        }

        public ColorSelector ColorSelector { get; }
        public SizeSelector SizeSelector { get; }

        public string ProductName => productRoot.FindElement(productNameLocator).Text;
        public double Price => double.Parse(productRoot.FindElement(productPriceLocator).Text.Replace("$", ""));
        private IWebElement AddToCartButton => productRoot.FindElement(addToCartLocator);

        // Clicks the Add to Cart Button, updates 
        public void ClickAddToCartButton(TestCart myCart)
        {
            TestProduct thisProduct = new TestProduct(ProductName, Price);

            // Get current state of mini cart, before adding the product to it
            MiniShoppingCart miniCart = new MiniShoppingCart(Driver);
            int currentCartCount = miniCart.GetMiniCartCounter();
            
            // Click on Add to Cart - Explicitely move mouse over product square so button is visible
            UserActions
                .MoveToElement(productRoot)
                .MoveToElement(AddToCartButton)
                .Click()
                .Perform();
            
           // Track addition of product in our test cart
            myCart.AddToCart(thisProduct);
            
            // Wait for MiniCart counter to update
            Wait.Until(miniCart.CounterIsUpdated(currentCartCount));
            
        }
    }
}
