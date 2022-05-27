using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    public class EmailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public EmailPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement emailField => _driver.FindElement(By.XPath("//input[@type='email']"));

        private IWebElement nextButton => _driver.FindElement(By.XPath("//input[@type='submit']"));


        public void WriteEmail(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(emailField)).SendKeys(email);
        }

        public void PressNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click();
        }
    }

}
