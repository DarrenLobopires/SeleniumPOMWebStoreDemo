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
    [TestCategory("Search")]
    public class SearchTests : BaseTest
    {

        [TestMethod]
        public void SearchedKeywordInAllResults()
        {
            // Assets
            string searchPhrase = "Tee";

            // Navigate to page
            HomePage homePage = new HomePage(Driver).GoToPage();

            // Peform tests: Search keyword, search products, filter results
            SearchResultsPage searchResultsPage = homePage.NavigationBar.SearchForProduct(searchPhrase);

            List<ProductSquare> searchResults = searchResultsPage.ProductGrid.GetAllProducts();
            List<ProductSquare> filteredResults = searchResultsPage.ProductGrid.GetAllMatchingProducts(prodEle => prodEle.ProductName.Contains(searchPhrase));

            // Assert searched keyword is present in each product's title. i.e., filtered results are the same as searched results           
            Assert.AreEqual(searchResults.Count, filteredResults.Count);

        }

    }
}
