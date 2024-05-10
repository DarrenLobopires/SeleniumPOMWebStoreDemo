using OpenQA.Selenium;
using SeleniumPOM_LumaStore_Demo.Pages.Interfaces;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class QuantitySelector : BaseComponent, IQuantity
    {

        public QuantitySelector(IWebDriver driver) : base(driver) { }

        private IWebElement QuantityField => Driver.FindElement(By.ClassName("cart-item-qty"));

        public int Quantity
        {
            get
            {
                string qtyString = QuantityField.GetAttribute("data-item-qty");
                return Int32.TryParse(qtyString, out int quantity) ? quantity : 0;
            }
        }

        
        // Clear Quantity Field
        public void ClearQuantity()
        {
            QuantityField.Clear();
        }

        public void InputQuantity(int quantity) 
        {
            string qtyString = quantity.ToString();
            QuantityField.SendKeys(qtyString); 
        }

    }
}