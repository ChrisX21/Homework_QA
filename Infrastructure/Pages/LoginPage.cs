using OpenQA.Selenium;

namespace Infrastructure.Pages;

public class LoginPage
{
    private IWebDriver _driver;
    private readonly By _usernameField = By.XPath("//input[@id='user-name']");
    private readonly By _passwordField = By.XPath("//input[@id='password']");
    private readonly By _loginButton = By.XPath("//input[@id='login-button']");
    private readonly By _errorMessage = By.XPath("//div[contains(@class, 'error-message-container')]");
   
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com");
    }

    public void Login(string username, string password)
    {
        _driver.FindElement(_usernameField).SendKeys(username);
        _driver.FindElement(_passwordField).SendKeys(password);
        _driver.FindElement(_loginButton).Click();
    }

    public bool IsErrorMessageDisplayed()
    {
        return _driver.FindElement(_errorMessage).Displayed;
    }
}
