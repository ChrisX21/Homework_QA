namespace Homework_selenium_tests
{
    public class HomePageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        [Test]
        public void Test_PageTitle()
        {
            Assert.AreEqual("Swag Labs", _driver.Title);
        }

        [Test]
        public void Test_LoginFormExists()
        {
            var usernameField = _driver.FindElement(By.XPath("//input[@id='user-name']"));
            var passwordField = _driver.FindElement(By.XPath("//input[@id='password']"));
            var loginButton = _driver.FindElement(By.XPath("//input[@id='login-button']"));

            Assert.IsTrue(usernameField.Displayed);
            Assert.IsTrue(passwordField.Displayed);
            Assert.IsTrue(loginButton.Displayed);
        }

        [Test]
        public void Test_InvalidLogin()
        {
            _driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys("invalid_user");
            _driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("invalid_pass");
            _driver.FindElement(By.XPath("//input[@id='login-button']")).Click();

            var errorMessage = _driver.FindElement(By.XPath("//div[contains(@class, 'error-message-container')]"));
            Assert.IsTrue(errorMessage.Displayed);
        }

        [Test]
        public void Test_ValidLogin()
        {
            _driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys("standard_user");
            _driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("secret_sauce");
            _driver.FindElement(By.XPath("//input[@id='login-button']")).Click();

            var inventoryPage = _driver.FindElement(By.XPath("//div[@class='inventory_list']"));
            Assert.IsTrue(inventoryPage.Displayed);
        }

        [Test]
        public void Test_AddProductToCart()
        {
            Test_ValidLogin();
            
            var addToCartButton = _driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']"));
            addToCartButton.Click();
            
            var cartBadge = _driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
            Assert.AreEqual("1", cartBadge.Text);
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
