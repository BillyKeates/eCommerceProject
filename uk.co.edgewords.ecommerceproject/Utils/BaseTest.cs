using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.ecommerceproject.Utils
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected string browser;

        [SetUp]
        public void SetUp()
        {



            driver = new FirefoxDriver();

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}
