using MyFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace MyFramework.StepDefintions
{
    [Binding]
    public class MyFrameworkSteps
    {


        IWebDriver _driver = BaseClass.GetDriver();
        WebDriverWait _wait = BaseClass.GetWait();


        [Given(@"User Loginned and he is on Lead Source page")]
        public void GivenUserLoginnedAndHeIsOnLeadSourcePage()
        {
            LogInPage loginPage = new LogInPage(_driver, _wait);
            loginPage.ClickLoginButton();
            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.WriteEmail("automation.pp@amdaris.com");
            emailPage.PressNextButton();
            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
            passwordPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressSignInButton();
            CheckBoxPage checkBoxPage = new CheckBoxPage(_driver, _wait);
            checkBoxPage.CheckBoxSelect();
            checkBoxPage.ClickNoButton();
            MainPage mainPage = new MainPage(_driver, _wait);
            mainPage.MoveToSettingsTab();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.MoveToLeadSourceTab();
        }

        [When(@"user click on Add Lead Source Button")]
        public void WhenUserClickOnAddLeadSourceButton()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.MoveToAddLeadSourceTab();
        }

        [When(@"user enter the Name of Lead Source")]
        public void WhenUserEnterTheNameOfLeadSource()
        {
            AddLeadSourcePage addLeadSourceTab = new AddLeadSourcePage(_driver, _wait);
            addLeadSourceTab.WriteName("Lorem Ipsum");
        }

        [When(@"user click the Note field")]
        public void WhenUserClickTheNoteField()
        {
            AddLeadSourcePage addLeadSourcePage = new AddLeadSourcePage(_driver, _wait);
            addLeadSourcePage.SelectNoteField();
        }

        [When(@"user enter the note of Lead Source")]
        public void WhenUserEnterTheNoteOfLeadSource()
        {
            AddLeadSourcePage addLeadSourcePage = new AddLeadSourcePage(_driver, _wait);
            addLeadSourcePage.WriteNote("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
        }

        [When(@"user click the Save button")]
        public void WhenUserClickTheSaveButton()
        {
            AddLeadSourcePage addLeadSourcePage = new AddLeadSourcePage(_driver, _wait);
            addLeadSourcePage.ClickSaveButton();
        }

        [Then(@"user see Successfully Added message")]
        public void ThenUserSeeSuccessfullyAddedMessage()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.AssertAdding("Lead Source added successfully.");
        }


        [When(@"user click on created on button")]
        public void WhenUserClickOnCreatedOnButton()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.SortButtonClick();
        }

        [Then(@"user see last edited Lead Source on top")]
        public void ThenUserSeeLastEditedLeadSourceOnTop()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.AssertSorting();
        }

        [When(@"user doing search on Lead Source Page")]
        public void WhenUserDoingSearchOnLeadSourcePage()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.SearchByLeadSource();
        }

        [When(@"user click on edit button")]
        public void WhenUserClickOnEditButton()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.EditLeadSource();
        }

        [When(@"user assign a new name for Lead Source")]
        public void WhenUserAssignANewNameForLeadSource()
        {
            AddLeadSourcePage addLeadSourceTab = new AddLeadSourcePage(_driver, _wait); ;
            addLeadSourceTab.WriteName(" Edited");
        }

        [When(@"user click Save button")]
        public void WhenUserClickSaveButton()
        {
            AddLeadSourcePage addLeadSourceTab = new AddLeadSourcePage(_driver, _wait);
            addLeadSourceTab.ClickSaveButton();
        }

        [Then(@"user see Successfully updated message")]
        public void ThenUserSeeEditedLeadSourceOnLeadSourcePage()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.AssertNameVisibility(" updated ");

        }

        [When(@"user assign a new note for Lead Source")]
        public void WhenUserAssignANewNoteForLeadSource()
        {
            AddLeadSourcePage addLeadSourceTab = new AddLeadSourcePage(_driver, _wait);
            addLeadSourceTab.ClearNote("");
            addLeadSourceTab.WriteNote("Nulla facilisi. Cras ac nisi libero. Nunc elementum turpis sed sem elementum, a rhoncus purus dictum.");
        }

        [Then(@"user see new note on Lead Source")]
        public void ThenUserSeeNewNoteOnLeadSource()
        {
            AddLeadSourcePage addLeadSourceTab = new AddLeadSourcePage(_driver, _wait);
            addLeadSourceTab.AsssertNoteVisibility();
        }

        [Then(@"user click Save button")]
        public void ThenUserClickSaveButton()
        {
            AddLeadSourcePage addLeadSourceTab = new AddLeadSourcePage(_driver, _wait);
            addLeadSourceTab.ClickSaveButton();
        }

        [When(@"user click on delete button")]
        public void WhenUserClickOnDeleteButton()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.DeleteLeadSource();
        }

        [When(@"usesr click Yes on confirmation button")]
        public void WhenUsesrClickYesOnConfirmationButton()
        {
            LeadSourcePage leadSourcePage = new LeadSourcePage(_driver, _wait);
            leadSourcePage.ConfirmationDeleteLeadSource();
        }

        [Then(@"user see Successfully deleted message")]
        public void ThenUserSeeSuccessfullyDeletedMessage()
        {
            LeadSourcePage leadSourcePageAssert = new LeadSourcePage(_driver, _wait);
            leadSourcePageAssert.AssertDeleting("LEAD source DELETED successfully");
        }



    }
}
