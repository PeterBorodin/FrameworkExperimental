using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    public class PasswordPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public PasswordPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private By passwordField => By.XPath("//input[@type='password']");
        private By submitButton => By.XPath("//input[@type='submit']");


        public void WritePassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(password);
        }

        public void PressSignInButton()
        {
            _wait.Until(ExpectedConditions.ElementExists(submitButton)).Click();
        }
    }
}
