using SeleniumPOM_LumaStore_Demo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM_LumaStore_Demo.Tests
{
    [TestClass]
    [TestCategory("End to End Tests")]
    public class EndToEndTests : BaseTest
    {
        [Description("Guest Adds a product to cart from home page and checks out")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]
        public void GuestAddProductFromHomePageToCartAndCheckOut()
        {
            // Test Assets
            TestCart myCart = new TestCart();

            // Navigate to pages under test
            HomePage homePage = new HomePage(Driver).GoToPage();
            MiniShoppingCart miniShoppingCart = homePage.NavigationBar.MiniShoppingCart;

            // Perform tests
            // Get products displayed on page
            ProductGrid productGrid = homePage.ProductGrid;

            // Check if we have enough search results to continue the test
            if (productGrid.ProductCount == 0)
            {
                throw new AssertInconclusiveException("HomePage has no products displayed.\n");
            }


            // Add a product to the cart
            SelectProductCriteriaAndAddToCart(productGrid.GetAllProducts()[0], myCart);

            // Proceed to Checkout
            ShippingPage shippingPage = miniShoppingCart.ProceedToCheckOut();

            // Fill out Shipping Page and submit
            shippingPage.FillOutShopperInfoFields("Guest", "Guest", "guest@test.com", "5555555555");
            shippingPage.FillOutShopperAddressFields("123 Fake street", "SeleniumVille", "Canada", "Ontario", "a1b 2c3");
            ReviewAndPaymentPage reviewAndPaymentPage = shippingPage.ClickNextWithValidFields();

            // Place Order
            OrderSuccessPage orderSuccessPage = reviewAndPaymentPage.PlaceOrderSuccessfully();

            // Assert completed Order
            int orderNumber = Int32.Parse(orderSuccessPage.OrderNumber);
            Assert.IsTrue(orderNumber > 0, $"orderNumber invalid! Displayed Order Number = {orderNumber}");
        }

        [Description("Guest Adds a product to cart from home page and checks out")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]


        // HELPER FUNCTIONS

        private void SelectProductCriteriaAndAddToCart(ProductSquare productSquare, TestCart myCart)
        {
            productSquare
                .ColorSelector
                .ClickFirstColor();
            productSquare
                .SizeSelector
                .ClickLargeSize();
            productSquare
                .ClickAddToCartButton(myCart);        
        }
    }
}
