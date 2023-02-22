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
    internal class TestCase2 : Utils.BaseTest
    {

        [Test, Category("TestCase2")]
        public void Test2()
        {
            Console.WriteLine("Test starting.");
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";

            //Create POM objects
            TopNavPOM topNav = new TopNavPOM(driver);
            LogInPagePOM login = new LogInPagePOM(driver);
            ShopPagePOM shop = new ShopPagePOM(driver);
            CartPagePOM cart = new CartPagePOM(driver);
            CheckoutPagePOM checkout = new CheckoutPagePOM(driver);
            MyAccountPagePOM myAccount = new MyAccountPagePOM(driver);

            //Enter username and password into input elements
            login.EnterUsername("billy.keates@nfocus.co.uk");
            login.EnterPassword("billykeates");
            login.ClickLogIn();

            //go to Shop page
            topNav.GoToShopPage();
            Console.WriteLine("On shop page.");

            //Click to add item to cart
            shop.AddItemToCart();

            //Go to Cart page
            shop.ViewCart();
            Console.WriteLine("On cart page.");

            //Check if demo store notice is displayed
            //Click dismiss if it is
            cart.DismissAlert();

            //Go to checkout
            cart.GoToCheckout();
            Console.WriteLine("On Checkout page.");

            checkout.EnterFirstName(Environment.GetEnvironmentVariable("FIRSTNAME"));
            checkout.EnterLastName(Environment.GetEnvironmentVariable("LASTNAME"));
            checkout.EnterStreetAddress(Environment.GetEnvironmentVariable("STREET"));
            checkout.EnterCity(Environment.GetEnvironmentVariable("CITY"));
            checkout.EnterPostcode(Environment.GetEnvironmentVariable("POSTCODE"));
            checkout.EnterPhoneNo(Environment.GetEnvironmentVariable("PHONENO"));

            //Problem with accessing the payment method box, the waits do not solve the issue so thread.sleep used instead
            Thread.Sleep(1000);
            checkout.SelectPaymentMethod();
            checkout.PlaceOrder();

            //store order number after order placed
            string orderNum1 = checkout.GetOrderNum1();
            Console.WriteLine("Order number is " + orderNum1);

            //Go to My account page
            topNav.GoToMyAccountPage();
            Console.WriteLine("On My account page.");

            //Go to My account => Orders page
            myAccount.GoToOrders();
            Console.WriteLine("On My account => orders page.");

            //read latest order number on orders page
            string orderNum2 = myAccount.GetOrderNum2();
            Console.WriteLine("Order number 2 is: " + orderNum2);

            try
            {

                Assert.That(orderNum2, Is.EqualTo(orderNum1), "Order number not found");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Test finished.");
        }


        

    }
}
