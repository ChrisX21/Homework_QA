using Infrastructure.Factories;
using Infrastructure.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Infrastructure.Tests
{
    public class ProductTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
            _loginPage.Open();
        }

        [Test]
        public void Test_AddProductToCart()
        {
            var validUser = UserFactory.GetValidUser();
            _loginPage.Login(validUser.Username, validUser.Password);

            _driver.FindElement(By.XPath("//button[contains(text(), 'Add to cart')]")).Click();
            var cartBadge = _driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));

            Assert.IsTrue(cartBadge.Displayed);
            Assert.AreEqual("1", cartBadge.Text);
        }

        [Test]
        public void Test_RemoveProductFromCart()
        {
            var validUser = UserFactory.GetValidUser();
            _loginPage.Login(validUser.Username, validUser.Password);
            
            _driver.FindElement(By.XPath("//button[contains(text(), 'Add to cart')]")).Click();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
            _driver.FindElement(By.XPath("//button[contains(text(), 'Remove')]")).Click();
            var cartBadge = _driver.FindElements(By.XPath("//span[@class='shopping_cart_badge']"));
            
            Assert.AreEqual(0, cartBadge.Count);
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}