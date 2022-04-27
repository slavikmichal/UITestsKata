using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class SeleniumTestsExample
    {
        IWebDriver? driver;

        [SetUp]
        public void startBrowser()
        {
            // TODO: Place here path to you chrome driver
            driver = new ChromeDriver("D:\\Documents\\pv260\\chromedriver_win32");
        }

        [Test]
        public void OrderProcessTest()
        {
            driver.Url = "https://www.saucedemo.com";

            // TODO: Place your test code here
            driver.FindElement(By.Name("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Name("login-button")).Submit();
            
            driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack")).Click();
            Assert.AreEqual("1", driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
            
            driver.FindElement(By.Name("add-to-cart-sauce-labs-bike-light")).Click();
            Assert.AreEqual("2", driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
            
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            
            Assert.True(driver.FindElement(By.PartialLinkText("Sauce Labs Backpack")).Displayed);
            Assert.True(driver.FindElement(By.PartialLinkText("Sauce Labs Bike Light")).Displayed);
            
            driver.FindElement(By.Name("checkout")).Click();

            driver.FindElement(By.Name("firstName")).SendKeys("Michal");
            driver.FindElement(By.Name("lastName")).SendKeys("Slavik");
            driver.FindElement(By.Name("postalCode")).SendKeys("61300");


            driver.FindElement(By.Name("continue")).Click();
            
            Assert.True(driver.FindElement(By.PartialLinkText("Sauce Labs Backpack")).Displayed);
            Assert.True(driver.FindElement(By.PartialLinkText("Sauce Labs Bike Light")).Displayed);
            
            driver.FindElement(By.Name("finish")).Click();
            
            Assert.True(driver.FindElement(By.ClassName("pony_express")).Displayed);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }

}