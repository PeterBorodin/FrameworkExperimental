using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    class MainPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private By settingsButton => By.XPath("//a[@id='settings-tab']");

        public void MoveToSettingsTab()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(settingsButton)).Click();
        }
    }
}
