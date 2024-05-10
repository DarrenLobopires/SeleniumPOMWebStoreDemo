using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM_LumaStore_Demo.Resources
{
    public class TestUser
    {
        // Defaults
        public TestUser():this("test", "test", "selenium89@test.com", "Selenium123") { }
        // Custom Pass
        public TestUser(string password) : this("test", "test", "selenium89@test.com", password) { }
        // custom name, email, pass
        public TestUser(string fn, string ln, string email, string pass)
        {
            FirstName = fn;
            LastName = ln;
            Email= email;
            Password = pass;
        }

        public string FirstName { get; } 
        public string LastName { get; } 
        public string Email { get; } 
        public string Password { get; } 

}


}
