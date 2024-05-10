using OpenQA.Selenium;
using SeleniumPOM_LumaStore_Demo.Pages.Interfaces;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    internal class PPQuantityField : BaseComponent, IQuantity
    {
        public PPQuantityField(IWebDriver driver) : base(driver) {}

        private IWebElement QuantityField => Driver.FindElement(By.Id("qty"));
        private IWebElement QuantityError => Driver.FindElement(By.Id("qty-error"));
        
        public int Quantity
        {
            get
            {
                string qtyString = QuantityField.GetAttribute("value");
                return Int32.TryParse(qtyString, out int quantity) ? quantity : 0;
            }
        }

        public void ClearQuantity()
        {
            QuantityField.Clear();
        }

        public void InputQuantity(int i)
        {
            throw new NotImplementedException();
        }

        public string CheckQuantityErrorMessage()
        {
            Wait.Until(ErrorMessageDisplayed());
            return QuantityError.Text;
        }


        // Returns Delegate which checks if errormessage element contains text
        private Func<IWebDriver, bool> ErrorMessageDisplayed()
        {
            return (d) => string.IsNullOrWhiteSpace(QuantityError.Text) ? false : true;
        }
    }
}