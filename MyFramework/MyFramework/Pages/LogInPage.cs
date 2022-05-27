using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    public class LogInPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LogInPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement loginButton => _driver.FindElement(By.ClassName("button"));

        public void ClickLoginButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(loginButton)).Click();
        }
    }
}
