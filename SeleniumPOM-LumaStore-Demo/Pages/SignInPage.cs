using OpenQA.Selenium;

namespace SeleniumPOM_LumaStore_Demo.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(d => d.FindElement(By.ClassName("page-title")).Text == "Customer Login");
        }

        public IWebElement EmailField => Driver.FindElement(By.Id("email"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("pass"));
        public IWebElement SignInButton => Driver.FindElement(By.Id("send2"));
        public string SignInErrorMessage
        {
            get
            {
                // Wait until element exists
                IWebElement element = Wait.Until(d => d.FindElement(By.CssSelector(".message-error.error.message")));
                // Wait until elemt text is populated
                Wait.Until(d =>  !String.IsNullOrEmpty(element.Text));
                //Return element text
                return element.Text;
            }
        }

        public HomePage LoginWithValidCustomerCredentials(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            SignInButton.Click();
            // Wait for homepage banner to load
            HomePage h = new HomePage(Driver);
            Wait.Until(d => h.NavigationBar.Greeting.Contains("Welcome"));
            
            return h;
        }

        internal SignInPage LoginWithInvalidCustomerCredentials(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            SignInButton.Click();

            // Returning a new Sign in Page since page reloads
            return new SignInPage(Driver);
        }
    }
}