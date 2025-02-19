using OpenQA.Selenium;

namespace Infrastructure.Pages;

public class CheckoutPage
{
    IWebDriver _driver;
    private readonly By _firstNameField = By.XPath("//input[@id='first-name']");
    private readonly By _lastNameField = By.XPath("//input[@id='last-name']");
    private readonly By _postalCodeField = By.XPath("//input[@id='postal-code']");
    private readonly By _finishButton = By.XPath("//button[contains(text(), 'Finish')]");
    
    public CheckoutPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void FillOutForm(string firstName, string lastName, string postalCode)
    {
        _driver.FindElement(_firstNameField).SendKeys(firstName);
        _driver.FindElement(_lastNameField).SendKeys(lastName);
        _driver.FindElement(_postalCodeField).SendKeys(postalCode);
        ClickContinue();
    }
    
    public bool IsFinishButtonDisplayed()
    {
        return _driver.FindElement(_finishButton).Displayed;
    }
    
    public void ClickFinish()
    {
        _driver.FindElement(_finishButton).Click();
    }
    
    public void ClickContinue()
    {
        _driver.FindElement(By.Id("continue")).Click();
    }
}