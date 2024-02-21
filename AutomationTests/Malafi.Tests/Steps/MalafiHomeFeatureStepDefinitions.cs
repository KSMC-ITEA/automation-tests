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

        private DocumentsGroup documentsGroupPage;
        public MalafiHomeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;

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



        [When(@"Clicked Documents Group link")]
        public void WhenClickedDocumentsGroupLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
// this step give key dictionary for the page calss (key hashing)
            scenarioContext["DocumentsGroupForm"] = documentsGroupPage;
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
        }

        [Then(@"I should be navigated to Documents Group Page")]
        public void ThenIShouldBeNavigatedToDocumentsGroupPage()
        {
            Assert.AreEqual("Add Documents Group", documentsGroupPage.AddDocumentsGroupButton.Text);
        }


    }
}
