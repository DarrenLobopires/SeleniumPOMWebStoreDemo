using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class SignInTests : BaseTest
    {
        [Description("User signs into webstore with valid credentials")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]
        public void SignInWithValidCredentials()
        {
            // Test Assets
            TestUser testUser = new TestUser();

            // Load page under test
            HomePage homePage = new HomePage(Driver).GoToPage();
            SignInPage signInPage = homePage.NavigationBar.ClickSignIn();

            // Perform test actions
            HomePage customerHomePage = signInPage.LoginWithValidCustomerCredentials(testUser.Email, testUser.Password);

            // Assert
            string ActualWelcomeMsg = customerHomePage.NavigationBar.Greeting;
            string ExpectedWelcomeMsg = String.Format("Welcome, {0} {1}!", testUser.FirstName, testUser.LastName);
            Assert.AreEqual(ExpectedWelcomeMsg, ActualWelcomeMsg);


        }

        [Description("User signs into webstore with valid credentials")]
        [TestProperty("Author", "Darren Lobo-Pires")]
        [TestMethod]
        public void SignInWithInvalidCredentials() 
        {
            // Test Assets
            TestUser testUser = new TestUser("WrongPass");

            // Load page under test
            HomePage homePage = new HomePage(Driver).GoToPage();
            SignInPage signInPage = homePage.NavigationBar.ClickSignIn();

            // Perform test actions
            SignInPage failedSignInPage = signInPage.LoginWithInvalidCustomerCredentials(testUser.Email, testUser.Password);

            // Assert
            string actualErrorString = failedSignInPage.SignInErrorMessage;
            Assert.IsTrue(actualErrorString.Contains("incorrect"));

            



        }
    }

    
}
