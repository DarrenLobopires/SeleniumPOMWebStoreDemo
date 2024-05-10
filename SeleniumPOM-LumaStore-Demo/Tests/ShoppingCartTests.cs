using OpenQA.Selenium.DevTools;
using SeleniumPOM_LumaStore_Demo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM_LumaStore_Demo.Tests
{
    [TestCategory("Add/Remove From Shopping Cards")]
    [TestClass]
    public class ShoppingCartTests : BaseTest
    {
        [TestMethod]
        public void AddThreeUniqueProductsFromHomePageUpdatesMiniCart() 
        {
            // Test Assets
            TestCart myCart = new TestCart();
            int numberOfTestProductsNeeded = 3;

            // Navigate to pages under test
            HomePage homePage = new HomePage(Driver).GoToPage();
            MiniShoppingCart miniShoppingCart = homePage.NavigationBar.MiniShoppingCart;

            // Perform tests
            // Get products displayed on page
            ProductGrid productGrid = homePage.ProductGrid;

            // Check if we have enough search results to continue the test
            if (productGrid.ProductCount < numberOfTestProductsNeeded)
            {
                throw new AssertInconclusiveException(String.Format("HomePage has too few products for this test.\n" +
                    "Minimum required products: {0}.\n" +
                    "Actual number of products: {1}.\n"
                    , numberOfTestProductsNeeded, productGrid.ProductCount));
            }

            // Add products to cart
            // Note: The home page refreshes each time we add to cart. Therefore, we have to re-search each product to avoid stale elements from the refresh
            SelectProductCriteriaAndAddToCart(productGrid.GetAllProducts()[0], myCart);
            SelectProductCriteriaAndAddToCart(productGrid.GetAllProducts()[1], myCart);
            SelectProductCriteriaAndAddToCart(productGrid.GetAllProducts()[2], myCart);


            // Pull Expected (test cart) and Actual cart (web mini cart)
            List<CartProduct> actualProductsInCart = miniShoppingCart.OpenCartDrawer().GetCartProducts();
            List<TestProduct> expectedProductsInCart = myCart.GetProductsInCart();

            // myCart is expected (tracked in test), miniShoppingCart is actual value (pull from page object)
            AssertMiniCartMatchesExpectedQuntityAndDetails(actualProductsInCart, expectedProductsInCart);


        }



        [TestMethod]
        public void AddThreeUniqueProductsFromSearchResultsPagUpdatesMiniCart()
        {
            // Test Assets
            string searchQuery = "tee";
            TestCart myCart = new TestCart();
            int numberOfTestProductsNeeded = 3;

            // Page Objects - Go directly to search results page via url query
            SearchResultsPage searchResultsPage = new SearchResultsPage(Driver).GoToPage(searchQuery);
            MiniShoppingCart miniShoppingCart = searchResultsPage.NavigationBar.MiniShoppingCart;

            // Perform tests
            // Check if we have enough products in product grid to continue the test
            ProductGrid productGrid = searchResultsPage.ProductGrid;
            if (productGrid.ProductCount < numberOfTestProductsNeeded)
            {
                throw new AssertInconclusiveException(String.Format("Too few results returned for search criteria: '{0}'. Consider a different search.\n" +
                    "Minimum required results: {1}.\n" +
                    "Actual number of returned results: {2}.\n"
                    , searchQuery, numberOfTestProductsNeeded, productGrid.ProductCount));
            }
            
            // Get products displayed on page
            List<ProductSquare> productSquares = productGrid.GetAllProducts();
            
            // Add products to cart
            SelectProductCriteriaAndAddToCart(productSquares[0], myCart);
            SelectProductCriteriaAndAddToCart(productSquares[1], myCart);
            SelectProductCriteriaAndAddToCart(productSquares[2], myCart);

            // Pull Expected Cart(test cart) and Actual cart (web mini cart)
            List<CartProduct> actualProductsInCart = miniShoppingCart.OpenCartDrawer().GetCartProducts();
            List<TestProduct> expectedProductsInCart = myCart.GetProductsInCart();

            // Validate mini cart as expected count and product details
            AssertMiniCartMatchesExpectedQuntityAndDetails(actualProductsInCart, expectedProductsInCart);

        }


        // HELPER FUNCTIONS
        private static void AssertMiniCartMatchesExpectedQuntityAndDetails(List<CartProduct> actualProductsInCart, List<TestProduct> expectedProductsInCart)
        {
            // Validate mini cart has the excpected amount of products in cart
            if (expectedProductsInCart.Count() != actualProductsInCart.Count())
            {
                throw new AssertFailedException(String.Format("Actual number of items in cart does not match expected.\n" +
                    "Expected Cart Count: {0}\n" +
                    "Actual Cart Count: {1}\n"
                    , expectedProductsInCart.Count(), actualProductsInCart.Count()));
            }
            // Validate all products in mini cart match expected product properties
            for (int i = 0; i < actualProductsInCart.Count(); i++)
            {
                CartProduct actualProduct = actualProductsInCart[i];
                TestProduct expectedProduct = expectedProductsInCart[i];
                if (expectedProduct.Name != actualProduct.Name || expectedProduct.Price != actualProduct.Price || expectedProduct.Quantity != actualProduct.QuantitySelector.Quantity)
                {
                    throw new AssertFailedException(String.Format("Actual Product in cart position {0} does not match Expected.\n" +
                        "Expected Product:\n{1}\n" +
                        "Actual Product:\n{2}\n"
                        , i, expectedProduct.ToString(), actualProduct.ToString()));
                }

            }
        }

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
