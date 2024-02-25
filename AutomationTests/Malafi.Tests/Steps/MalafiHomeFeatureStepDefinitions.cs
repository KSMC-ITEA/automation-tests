using DocumentFormat.OpenXml.Drawing;
using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private RegisteredEmployees registeredEmployees;
        private Dashboards dashboards;

        private DocumentsGroup documentsGroupPage;
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
        public void WhenClickedEmployeesSearchlink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            Thread.Sleep(1100);
            employeesSearch = malafiHome.ClickOnEmployeesSearch();
            employeesSearch.Wait.Until(ExpectedConditions.ElementToBeClickable(employeesSearch.EmployeesSearchVLD));
        }

        [Then(@"I should be navigated to Employees Search Page")]
        public void ThenIShouldBeNavigatedToEmployeesSearchPage()
        {
            Assert.AreEqual("Name", employeesSearch.EmployeesSearchVLD.Text);

        }



        [When(@"Clicked Documents Group link")]
        public void WhenClickedDocumentsGroupLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
            scenarioContext["DocumentsGroupForm"] = documentsGroupPage;
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
        }

        [Then(@"I should be navigated to Documents Group Page")]
        public void ThenIShouldBeNavigatedToDocumentsGroupPage()
        {
            Assert.AreEqual("Add Documents Group", documentsGroupPage.AddDocumentsGroupButton.Text);
        }

        [When(@"Clicked Registered Employees link")]
        public void WhenClickedRegisteredEmployeesLink()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            scenarioContext["registeredEmployees"] = registeredEmployees;

            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();

        }

        [Then(@"I should be navigated to Registered Employees Page")]
        public void ThenIShouldBeNavigatedToRegisteredEmployeesPage()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();
     
            Assert.AreEqual("Approved", registeredEmployees.Approved.Text);


        }

        [Given(@"I click on Dashboard")]
        public void GivenIClickOnDashboard()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            dashboards = malafiHome.ClickOnExecutiveDashboard();

        }

        [Then(@"I shoed see Executive Dashboard")]
        public void ThenIShoedSeeExecutiveDashboard()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            dashboards = malafiHome.ClickOnExecutiveDashboard();
            Thread.Sleep(500);
            Assert.AreEqual("6", dashboards.AlRegisteredEmployees.Text);

        }


    }
}
