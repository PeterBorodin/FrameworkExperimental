using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    class AddLeadSourcePage : BaseClass
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public AddLeadSourcePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private By nameField => By.XPath("//input[@id = 'name']");
        private By nameFieldlist => By.XPath("//span[@class='cell-content']");
        private By noteField => By.Id("mat-input-1");
        private IWebElement saveButton => _driver.FindElement(By.XPath("//button[@type = 'submit']"));

        public void WriteName(string name)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(nameField)).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(nameField)).SendKeys(name);
        }

        public void SelectNoteField()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(noteField)).Click();
        }

        public void WriteNote(string note)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(noteField)).SendKeys(note);
        }

        public void ClearNote(string note)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(noteField)).Clear();
        }
        public void AsssertNoteVisibility()  //Assert IsNotNull
        {
            string actualResultEmployee = _wait.Until(ExpectedConditions.ElementIsVisible(noteField)).Text;
            Assert.IsNotNull(actualResultEmployee);
        }

        public void ClickSaveButton()
        {
            ThreadSleep();
            _wait.Until(ExpectedConditions.ElementToBeClickable(saveButton)).Click();
        }










    }
}
