using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class MalafiHomeFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        private DocumentType documentTypesPage;
        private RegisteredEmployees registeredEmployees;

        public MalafiHomeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");

        }
        [When(@"Clicked DocumentsTypes link")]
        public void WhenIClickedDocumentsTypesLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));
        }

        [Then(@"I should be navigated to Document Types Page")]
        public void ThenIShouldBeNavigatedToDocumentTypesPage()
        {
            Assert.AreEqual("Add Document Type", documentTypesPage.AddDocumentsTypes.Text);
        }

        [When(@"Clicked Registered Employees link")]
        public void WhenClickedRegisteredEmployeesLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();
            Thread.Sleep(1100);
            registeredEmployees.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployees.Approved));
        }

        [Then(@"I should be navigated to Registered Employees Page")]
        public void ThenIShouldBeNavigatedToRegisteredEmployeesPage()
        {
            Assert.AreEqual("Approved", registeredEmployees.Approved.Text);
        }

    }
}
