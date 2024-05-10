using OpenQA.Selenium;
using System.Xml.Linq;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class CartProduct : BaseComponent
    {
        private IWebElement productRoot;
        private By productNameLocator = By.CssSelector(".product-item-name");
        private By priceLocator = By.CssSelector(".price");
        public CartProduct(IWebDriver driver, IWebElement cartProdEle) : base(driver)
        {
            productRoot = cartProdEle;
            QuantitySelector = new QuantitySelector(Driver);

        }
        public QuantitySelector QuantitySelector { get; }
        public string Name => productRoot.FindElement(productNameLocator).Text;
        public double Price => double.Parse(productRoot.FindElement(priceLocator).Text.Replace("$", ""));


        public override string ToString()
        {
            return String.Format("Name: {0}\n" +
                "Price: {1:C}\n" +
                "Quantity: {2}\n"
                , Name, Price, QuantitySelector.Quantity);
        }

    }
}