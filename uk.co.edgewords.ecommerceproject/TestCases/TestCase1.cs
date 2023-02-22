using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.ecommerceproject.Utils;
using uk.co.edgewords.ecommerceproject.POMClass;

namespace uk.co.edgewords.ecommerceproject.TestCases
{
    internal class TestCase1: Utils.BaseTest
    {
         
        [Test, Category("TestCase1")]
        public void Test1()
        {

            
            Console.WriteLine("Test starting.");
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            //Create POM objects
            TopNavPOM topNav = new TopNavPOM(driver);
            LogInPagePOM login = new LogInPagePOM(driver);
            ShopPagePOM shop = new ShopPagePOM(driver);
            CartPagePOM cart = new CartPagePOM(driver);
            MyAccountPagePOM myAccount = new MyAccountPagePOM(driver);


            

            //Enter username and password into input elements
            login.EnterUsername(Environment.GetEnvironmentVariable("USERNAME"));
            login.EnterPassword(Environment.GetEnvironmentVariable("PASSWORD"));
            login.ClickLogIn();
            Assert.That(login.CheckIfLoggedIn(), Is.True, "Invalid log in details");


            //go to shop page
            topNav.GoToShopPage();
            Console.WriteLine("On shop page.");

            //Click to add item to cart and view cart
            shop.AddItemToCart();
            shop.ViewCart();
            Console.WriteLine("On cart page.");

            //Enter and apply the coupon
            cart.EnterCoupon(Environment.GetEnvironmentVariable("COUPON"));
            cart.ApplyCoupon();



            //Check that discount is correct
            bool isDiscountCorrect = cart.CheckDiscount();
            try
            {
                Assert.That(isDiscountCorrect, Is.True, "Discount is not 15%");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            //Check that total price is correct
            bool isTotalPriceCorrect = cart.CheckPrice();
            try
            {
                Assert.That(isTotalPriceCorrect, Is.True, "Total price is not correct");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            //Go to my account page
            topNav.GoToMyAccountPage();
            Console.WriteLine("On My Account page");
            
            //Log out of account
            myAccount.Logout();
            



            Console.WriteLine("Test finished.");

        }
        
        
        

    }
}
