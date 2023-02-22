using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.ecommerceproject.Utils;

namespace uk.co.edgewords.ecommerceproject.POMClass
{
    internal class ShopPagePOM
    {
        private IWebDriver _driver;



        public ShopPagePOM(IWebDriver driver)
        {
            this._driver = driver;
            
        }

        private IWebElement _addToCartBtn => _driver.FindElement(By.CssSelector(".post-28 > .button"));
        private IWebElement _viewCartBtn => _driver.FindElement(By.LinkText("View cart"));
        

        public void AddItemToCart()
        {
            _addToCartBtn.Click();
        }

        public void ViewCart()
        {
            

            //Set explicit wait until item is added to cart
            MyHelpers help = new MyHelpers(_driver);
            help.WaitForElement(By.LinkText("View cart"), 3);

            _viewCartBtn.Click();

        }

        

    }
}
