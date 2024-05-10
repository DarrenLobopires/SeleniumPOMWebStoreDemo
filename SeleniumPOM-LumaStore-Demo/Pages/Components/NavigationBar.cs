using OpenQA.Selenium;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class NavigationBar : BaseComponent
    {
        private By searchFieldLocator = By.Id("search");
        private By SearchButtonLocator = By.CssSelector(".action.search");
        private By SignInButtonLocator = By.CssSelector(".panel .authorization-link");
        public NavigationBar(IWebDriver driver) : base(driver) 
        {
            MiniShoppingCart = new MiniShoppingCart(Driver);
        }

        public string Greeting => Driver.FindElement(By.CssSelector(".greet.welcome span")).Text;
        public IWebElement SignInButton => Driver.FindElement(SignInButtonLocator);
        public IWebElement SearchField => Driver.FindElement(searchFieldLocator);
        public IWebElement SearchButton
        {
            get
            {
                // Wait for the button to be clickable before returning it
                var button = Driver.FindElement(SearchButtonLocator);
                Wait.Until(d => button.Displayed && button.Enabled);
                return button;
            }
        }
        public MiniShoppingCart MiniShoppingCart { get; internal set; }

        public SearchResultsPage SearchForProduct(string searchPhrase)
        {
            SearchField.Clear();
            SearchField.SendKeys(searchPhrase);
            SearchButton.Click();

            return new SearchResultsPage(Driver);
        }

        public SignInPage ClickSignIn()
        {
            SignInButton.Click();
            return new SignInPage(Driver);
        }
    }
}