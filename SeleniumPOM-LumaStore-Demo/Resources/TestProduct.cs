namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class TestProduct
    {
        public TestProduct(string name, double price, int quantity = 1) 
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public double Price { get; }
        public int Quantity { get; set; }

        public override string ToString() 
        {
            return String.Format("Name: {0}\n" +
                "Price: {1}\n" +
                "Quantity: {2}"
                , Name, Price, Quantity);
        }
    }
}