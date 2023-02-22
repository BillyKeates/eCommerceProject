using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.ecommerceproject.Utils;

namespace uk.co.edgewords.ecommerceproject.POMClass
{
    internal class CheckoutPagePOM
    {
        private IWebDriver _driver;

        public CheckoutPagePOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _userFirstName => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement _userLastName => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement _streetAddress => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement _userCity => _driver.FindElement(By.Id("billing_city"));
        private IWebElement _userPostcode => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement _userPhoneNo => _driver.FindElement(By.Id("billing_phone"));
        private IWebElement _paymentMethod => _driver.FindElement(By.CssSelector(".payment_method_cheque"));
        private IWebElement _placeOrderBtn => _driver.FindElement(By.Id("place_order"));
        private string _orderNum => _driver.FindElement(By.CssSelector(".woocommerce-order-overview__order > strong")).Text;


        public void EnterFirstName(string firstName)
        {
            _userFirstName.Clear();
            _userFirstName.SendKeys(firstName);

        }

        public void EnterLastName(string lastName)
        {
            _userLastName.Clear();
            _userLastName.SendKeys(lastName);
        }

        public void EnterStreetAddress(string streetAddress)
        {
            _streetAddress.Clear();
            _streetAddress.SendKeys(streetAddress);
        }

        public void EnterCity(string city)
        {
            _userCity.Clear();
            _userCity.SendKeys(city);
        }

        public void EnterPostcode(string postcode)
        {
            _userPostcode.Clear();
            _userPostcode.SendKeys(postcode);
        }
        public void EnterPhoneNo(string phoneNo)
        {
            _userPhoneNo.Clear();
            _userPhoneNo.SendKeys(phoneNo);
        }

        public void SelectPaymentMethod()
        {
            _paymentMethod.Click();
        }

        public void PlaceOrder()
        {
            _placeOrderBtn.Click();
        }

        public string GetOrderNum1()
        {
            MyHelpers help = new MyHelpers(_driver);
            help.WaitForElement(By.CssSelector(".woocommerce-order-overview__order"), 3);
            return _orderNum;
        }


    }
}
