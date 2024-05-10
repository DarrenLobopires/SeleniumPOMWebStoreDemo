using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Collections;
using System.Collections.ObjectModel;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class MiniShoppingCart : BaseComponent
    {
        private int count = 0;
        //private By cartCounterLocator = By.ClassName("counter-label");
        public MiniShoppingCart(IWebDriver driver) : base(driver) { }
        private IWebElement OpenCartButton => Driver.FindElement(By.ClassName("showcart"));
        private IWebElement CartDrawerContainer => Driver.FindElement(By.Id("minicart-content-wrapper"));
        private IWebElement ProceedToCheckOutButton => Driver.FindElement(By.Id("top-cart-btn-checkout"));
        private ReadOnlyCollection<IWebElement> CartProductElements => Driver.FindElements(By.CssSelector("#mini-cart .product-item"));
        private IWebElement CartCounterElement => Driver.FindElement(By.ClassName("counter-label"));

        // Returns cart counter if it can be parsed. Otherwise return 0 -> label is blank when 0 items
        public int GetMiniCartCounter()
        {
            if (Int32.TryParse(CartCounterElement.Text, out count))
            {
                return count;
            }
            return 0;
        }

        // Returns the products in the mini cart
        public List<CartProduct> GetCartProducts()
        {
            List<CartProduct> cartProducts = new List<CartProduct>();
            // Cart Product Elements transformed to CartProduct Objects. Product Objects stored into a new List. Reverse list
            cartProducts = CartProductElements.Select(cartProdEle => new CartProduct(Driver, cartProdEle)).ToList();
            cartProducts.Reverse();
            
            return cartProducts;
        }

        // Delegate returns true if Cart Counter Element is updated => has as a value & greater than previous value
        public Func<IWebDriver, bool> CounterIsUpdated(int currentCartCount)
        {
            return (d) =>
            {
                return !string.IsNullOrWhiteSpace(CartCounterElement.Text) && Int32.Parse(CartCounterElement.Text) > currentCartCount;
            };
        }

        public MiniShoppingCart OpenCartDrawer()
        {
            // Open cart drawer if currently closed
            if (!CartDrawerContainer.Displayed) 
            { 
                OpenCartButton.Click(); 
            }
            return this;
        }

        public ShippingPage ProceedToCheckOut()
        {
            // Open cart drawer if currently closed
            if (!CartDrawerContainer.Displayed)
            {
                OpenCartButton.Click();
            }
            // Click Proceed to Checkout
            ProceedToCheckOutButton.Click();
            return new ShippingPage(Driver);

        }
    }
}