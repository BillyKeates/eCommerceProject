using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.ecommerceproject.Utils;

namespace uk.co.edgewords.ecommerceproject.POMClass
{
    internal class CartPagePOM
    {

        private IWebDriver _driver;

        public CartPagePOM(IWebDriver driver)
        {
            this._driver = driver;
        }


        private IWebElement _couponInput => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement _applyCouponBtn => _driver.FindElement(By.CssSelector(".coupon > button"));

        private IWebElement _footerAlert => _driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link"));
        private IWebElement _checkoutBtn => _driver.FindElement(By.LinkText("Proceed to checkout"));


        private IWebElement _itemPrice => _driver.FindElement(By.CssSelector(".cart-subtotal > td"));
        private IWebElement _discount => _driver.FindElement(By.CssSelector(".cart-discount > td > .amount"));

        private IWebElement _shippingCost => _driver.FindElement(By.CssSelector("#shipping_method > li > label > span"));

        private IWebElement _totalPrice => _driver.FindElement(By.CssSelector(".order-total > td"));

        public void EnterCoupon(string coupon)
        {
            _couponInput.SendKeys(coupon);
        }

        public void ApplyCoupon()
        {
            _applyCouponBtn.Click();

        }

        


        public bool CheckDiscount()
        {
            
            double ItemPrice = Convert.ToDouble(_itemPrice.Text.Substring(1));

            MyHelpers help = new MyHelpers(_driver);
            help.WaitForElement(By.CssSelector(".cart-discount > td > .amount"), 3);
    


            double ActualDiscount = Convert.ToDouble(_discount.Text.Substring(1));

            double ExpectedDiscount = ItemPrice * 0.15;

            Console.WriteLine("The Expected discount is: "+ExpectedDiscount + ", the actual discount found was " + ActualDiscount);

            if(ActualDiscount == ExpectedDiscount)
            {
                return true;
            }
            return false;

        }

        public bool CheckPrice()
        {
            double ShippingPrice = Convert.ToDouble(_shippingCost.Text.Substring(1));

            double ActualPrice = Convert.ToDouble(_totalPrice.Text.Substring(1));

            double ItemPrice = Convert.ToDouble(_itemPrice.Text.Substring(1));
            double ExpectedDiscount = ItemPrice * 0.15;
            double ExpectedTotalPrice = (ItemPrice - ExpectedDiscount) + ShippingPrice;
            Console.WriteLine("The expected total is "+ExpectedTotalPrice + ", the actual total found was " + ActualPrice);


            if(ActualPrice == ExpectedTotalPrice)
            {
                return true;
            }

            return false;

            
        }


        public void DismissAlert()
        {
            if (_footerAlert.Displayed)
            {
                _footerAlert.Click();
            }
        }

        public void GoToCheckout()
        {
            _checkoutBtn.Click();
        }

    }
}
