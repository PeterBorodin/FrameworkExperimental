using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    class SettingsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public SettingsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private By leadSourceButton => By.XPath("//a[.=' Lead Source ']");

        public void MoveToLeadSourceTab()
        {
            _wait.Until(ExpectedConditions.ElementExists(leadSourceButton)).Click();
        }

    }
}
