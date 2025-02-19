using Infrastructure.Factories;
using Infrastructure.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Infrastructure.Tests;

public class LoginTests
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
    public void Test_InvalidLogin()
    {
        var invalidUser = UserFactory.GenerateInvalidUser();
        _loginPage.Login(invalidUser.Username, invalidUser.Password);

        Assert.IsTrue(_loginPage.IsErrorMessageDisplayed());
    }

    [Test]
    public void Test_ValidLogin()
    {
        var validUser = UserFactory.GetValidUser();
        _loginPage.Login(validUser.Username, validUser.Password);

        Assert.AreEqual("Swag Labs", _driver.Title);
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Quit();
    }
}               