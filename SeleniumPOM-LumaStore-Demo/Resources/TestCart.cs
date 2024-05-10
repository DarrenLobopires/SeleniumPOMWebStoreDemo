using SeleniumPOM_LumaStore_Demo.Pages;

namespace SeleniumPOM_LumaStore_Demo.Tests
{
    public class TestCart
    {
        private List<TestProduct> products = [];
        public int Count => products.Count;
        
        // Constructor for creating a new cart (initialize test asset)
        public TestCart() {}

        
        public void AddToCart(TestProduct product)
        {
            // Check if Product exists
            bool productExists = products.Exists(p => p.Name == product.Name);
            
            if (productExists) 
            {
                // Update Quantity of existing product
                products.First(p => p.Name == product.Name).Quantity++;
            }
            else
            {
                // Add the product
                products.Add(product);

            }
        }
        // Return list of products in cart
        public List<TestProduct> GetProductsInCart()
        { 
            return products; 
        }

    }
}