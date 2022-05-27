using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using BoDi;
using MyFramework.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MyFramework
{
    [Binding]
    public class BaseClass
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private IObjectContainer objectContainer;
        public BaseClass(IObjectContainer container)
        {
            objectContainer = container;
        }

        protected static IWebDriver _driver;
        protected static WebDriverWait _wait;

        [BeforeTestRun]
        public static void InitializeReport()
        {

            var htmlReporter = new ExtentHtmlReporter("C:\\Report\\ExtentReport.html");
            htmlReporter.Config.Theme = Theme.Dark;


            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeFeature]

        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]

        public static void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            var TestResult = ScenarioStepContext.Current.Status;

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

        }

        [AfterScenario]
        protected void DoAfterEach()
        {
            ThreadSleep();
            _driver.Close();
            _driver.Quit();
        }


        [BeforeScenario]
        protected void DoBeforeEach()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-pings");//Don't send hyperlink auditing pings

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(TestSettings.HostPrefix);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(6000);
            _wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(6000));
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            objectContainer.RegisterInstanceAs<WebDriverWait>(_wait);

            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        public static void ThreadSleep(int msToWait = 1000)
        {
            Thread.Sleep(msToWait);
        }
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
        public static WebDriverWait GetWait()
        {
            return _wait;
        }

    }
}