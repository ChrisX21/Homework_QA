using OpenQA.Selenium;

namespace Infrastructure.Pages;

public class CartPage
{
    IWebDriver _driver;
    private readonly By _checkoutButton = By.XPath("//button[contains(text(), 'Checkout')]");
    private readonly By _cartBadge = By.XPath("//span[@class='shopping_cart_badge']");
    
    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void ClickCheckout()
    {
        _driver.FindElement(_checkoutButton).Click();
    }
    
    public bool IsCartBadgeDisplayed()
    {
        return _driver.FindElement(_cartBadge).Displayed;
    }
    
    public void AddProductToCart()
    {
        _driver.FindElement(By.XPath("//button[contains(text(), 'Add to cart')]")).Click();
    }
    
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
    }
    
    public void RemoveProductFromCart()
    {
        _driver.FindElement(By.XPath("//button[contains(text(), 'Remove')]")).Click();
    }
    
}