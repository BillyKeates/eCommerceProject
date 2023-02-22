using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.ecommerceproject.POMClass
{
    internal class LogInPagePOM
    {

        private IWebDriver _driver;

        public LogInPagePOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _usernameElement => _driver.FindElement(By.Id("username"));
        private IWebElement _passwordElement => _driver.FindElement(By.Id("password"));
        private IWebElement _logInButton => _driver.FindElement(By.CssSelector(".woocommerce-form-login__submit"));
        

        public void EnterUsername(string username)
        {
            _usernameElement.Clear();
            _usernameElement.SendKeys(username);
        }


        public void EnterPassword(string password)
        {
            _passwordElement.Clear();
            _passwordElement.SendKeys(password);
        }

        public void ClickLogIn()
        {
            _logInButton.Click();
        }


        public bool CheckIfLoggedIn()
        {
            try
            {
                _driver.FindElement(By.LinkText("Logout"));
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
