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
        private Pages.EmployeesSearch employeesSearch;

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
            scenarioContext["DocumentTypesPage"] = documentTypesPage;
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));
        }

        [Then(@"I should be navigated to Document Types Page")]
        public void ThenIShouldBeNavigatedToDocumentTypesPage()
        {
            Assert.AreEqual("Add Document Type", documentTypesPage.AddDocumentsTypes.Text);
        }

        [When(@"Clicked Employees Search link")]
        public void WhenClickedRegisteredEmployeesLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            Thread.Sleep(1100);
            employeesSearch = malafiHome.ClickOnEmployeesSearch();
            employeesSearch.Wait.Until(ExpectedConditions.ElementToBeClickable(employeesSearch.EmployeesSearchVLD));
        }

        [Then(@"I should be navigated to Employees Search Page")]
        public void ThenIShouldBeNavigatedToRegisteredEmployeesPage()
        {
            Assert.AreEqual("Name", employeesSearch.EmployeesSearchVLD.Text);

        }

    }
}
