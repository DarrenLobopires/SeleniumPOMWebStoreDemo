using OpenQA.Selenium;
using SeleniumPOM_LumaStore_Demo.Pages;
using SeleniumPOM_LumaStore_Demo.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM_LumaStore_Demo.Tests
{
    [TestClass]
    [TestCategory("Product page tests for clothing items")]
    public class ClothingProductPageTests : BaseTest
    {
        [Description("User is prompted of required field if Add to Cart is clicked while Size not selected")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]
        public void UnableToAddToCartMissingSize()
        {
            // Test Assets
            string product = MenswearProducts.StrikeEnduranceTee;
            string firstWord = product.Split(' ')[0];

            // Navigate to page under test
            ProductPage productPage = new ProductPage(Driver).GoToPage(product);

            // Perform Test Actions: Omit Size, select a color, click add to cart
            productPage
                .ColorSelector
                .ClickLastColor();
            productPage
                .ClickAddToCartButton();

            // Save actual UI error message for validation
            string ActualError
                = productPage
                .CheckSizeErrorMessage();

            // Expected UI error message
            string ExpectedError = "required field";

            // Validate UI error message
            Assert.IsTrue(ActualError.Contains(ExpectedError), $"Expected Message: {ExpectedError} \nMessage: {ActualError}");
        }

        [Description("User is prompted of required field if Add to Cart is clicked while Color not selected")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]
        public void UnableToAddToCartMissingColor()
        {
            // Test Assets
            string product = MenswearProducts.StrikeEnduranceTee;

            // Navigate to page under test
            ProductPage productPage = new ProductPage(Driver).GoToPage(product);

            // Perform Test Actions: Select Size, Omit color, click add to cart
            productPage
                .SizeSelector
                .ClickLargeSize();
            productPage
                .ClickAddToCartButton();

            // Save actual UI error message for validation
            string ActualError
                = productPage
                .CheckColorErrorMessage();

            // Expected UI error message
            string ExpectedError = "required field";

            // Validate UI error message
            Assert.IsTrue(ActualError.Contains(ExpectedError), $"Expected Message: {ExpectedError} \nMessage: {ActualError}");
        }

        [Description("User is prompted of required field if Add to Cart is clicked while Quantity is Invalid")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]
        public void UnableToAddToCartMissingQuantity()
        {
            // Test Assets
            string product = MenswearProducts.StrikeEnduranceTee;

            // Navigate to page under test
            ProductPage productPage = new ProductPage(Driver).GoToPage(product);

            // Perform Test Actions: Select Size, select a color, invalid quantity, click add to cart
            productPage
                .SizeSelector
                .ClickLargeSize();
            productPage
                .ColorSelector
                .ClickLastColor();
            productPage
                .PPQuantityField
                .ClearQuantity();
            productPage
                .ClickAddToCartButton();

            // Save actual UI error message for validation
            string ActualError
                = productPage
                .PPQuantityField
                .CheckQuantityErrorMessage();

            // Expected UI error message
            string ExpectedError = "enter a valid number";

            // Validate UI error message
            Assert.IsTrue(ActualError.Contains(ExpectedError), $"Expected Message: {ExpectedError} \nMessage: {ActualError}");

        }

    }
}
