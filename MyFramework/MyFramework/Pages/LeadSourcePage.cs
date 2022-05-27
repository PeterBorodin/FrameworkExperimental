using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyFramework.Pages
{
    class LeadSourcePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LeadSourcePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private By addleadSourceButton => By.XPath("//span[@class = 'icon-btn-label']");
        private By leadSourceSearch => By.Id("leadSourceSearch");
        private By leadSourceDelete => By.XPath("//div/i[2]");
        private By confirmationDelete => By.XPath("//span[.='Yes']");
        private By leadSourceEdit => By.XPath("//div/i[last()-1]");
        private By assertEditing => By.XPath("//span[.='Lead Source updated successfully.']");
        private By assertAdding => By.XPath("//span[.='Lead Source added successfully.']");
        private By assertDeleting => By.XPath("//span[.='Lead source deleted successfully']");
        private By sortButton => By.XPath("//button[.=' Created At ']");
        private By assertSorting => By.XPath("//span[.='Lorem Ipsum']");

        public void MoveToAddLeadSourceTab()
        {
            int i = 0;

            while (i <= 1)
            {
                try
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(addleadSourceButton)).Click();
                }
                catch (StaleElementReferenceException) { }
                i++;
            }

        }

        public void SearchByLeadSource()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(leadSourceSearch)).SendKeys("Lorem Ipsum");

        }

        public void DeleteLeadSource()
        {
            _wait.Until(ExpectedConditions.ElementExists(leadSourceDelete)).Click();

        }

        public void ConfirmationDeleteLeadSource()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(confirmationDelete)).Click();

        }

        public void EditLeadSource()
        {
            int i = 0;

            while (i <= 3)
            {
                try
                {
                    _wait.Until(ExpectedConditions.ElementExists(leadSourceEdit)).Click();
                }
                catch (ElementClickInterceptedException) { }
                catch (StaleElementReferenceException) { }
                i++;
            }

        }
        public void SortButtonClick()
        {
            int i = 0;

            while (i <= 1)
            {
                try
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(sortButton)).Click();
                }
                catch (StaleElementReferenceException) { }
                i++;
            }

        }

        public void AssertAdding(string expectedResult)
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(assertAdding)).Text;
            Assert.AreEqual(expectedResult, actualResult);  //Assert AreEqual
        }

        public void AssertNameVisibility(string expectedResult)  //Assert Contains
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(assertEditing)).Text;
            StringAssert.Contains(expectedResult, actualResult);
        }

        public void AssertDeleting(string expectedResult)
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(assertDeleting)).Text;
            StringAssert.AreEqualIgnoringCase(expectedResult, actualResult);  //AreEqualIgnoringCase
        }

        public void AssertSorting()
        {
            bool actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(assertSorting)).Displayed;
            Assert.IsTrue(actualResult);  //Assertion IsTrue
        }


    }
}