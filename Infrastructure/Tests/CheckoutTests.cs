using Infrastructure.Factories;
using Infrastructure.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Infrastructure.Tests;

public class CheckoutTests
{
    private IWebDriver _driver;
    private LoginPage _loginPage;
    private CartPage _cartPage;
    private CheckoutPage _checkoutPage;
        
    [SetUp]
    public void Setup()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Window.Maximize();
        _loginPage = new LoginPage(_driver);
        _loginPage.Open();
        _cartPage = new CartPage(_driver);
        _checkoutPage = new CheckoutPage(_driver);
    }
    
    [Test]
    public void Test_Checkout()
    {
        var validUser = UserFactory.GetValidUser();
        _loginPage.Login(validUser.Username, validUser.Password);
        _cartPage.AddProductToCart();
        _cartPage.Open();
        _cartPage.ClickCheckout();
        _checkoutPage.FillOutForm(validUser.Username, validUser.Password, "12345");
        _checkoutPage.ClickFinish();
        
        Assert.AreEqual("Thank you for your order!", _driver.FindElement(By.XPath("//h2[contains(text(), 'Thank you for your order!')]")).Text);
    }
}