using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    public class CheckBoxPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public CheckBoxPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private By checkBox => By.Id("KmsiCheckboxField");
        private By buttonNo => By.Id("idBtn_Back");

        public void CheckBoxSelect()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(checkBox)).Click();

        }

        public void ClickNoButton()
        {
            _wait.Until(ExpectedConditions.ElementExists(buttonNo)).Click();

        }


    }
}
