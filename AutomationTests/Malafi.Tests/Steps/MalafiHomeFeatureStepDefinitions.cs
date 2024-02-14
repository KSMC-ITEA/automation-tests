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
        private DocumentType documentTypesPage;
        private DocumentsGroup documentsGroupPage;
        private RegisteredEmployees registeredEmployeesPage;
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
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));
        }

        [Then(@"I should be navigated to Document Types Page")]
        public void ThenIShouldBeNavigatedToDocumentTypesPage()
        {
            Assert.AreEqual("Add Document Type", documentTypesPage.AddDocumentsTypes.Text);
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

        /*   public RegisteredEmployees GetRegisteredEmployeesPage()
           {
               return registeredEmployeesPage;
           }*/

        [When(@"Clickd Registered Employee link")]
        public void WhenClickedRegisteredEmployeesLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            registeredEmployeesPage = malafiHome.ClickOnRegisterdEmployeesLink();
            scenarioContext["RegisteredEmployees"] = registeredEmployeesPage;
            registeredEmployeesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesPage.RegisteredEmployeesButton));

        }

        [Then(@"I should be navigated to the Registered employees page")]
        public void ThenIShouldBeNavigatedToRegisteredEmployeesPage()
        {
            Assert.AreEqual("Registered Employees", registeredEmployeesPage.RegisteredEmployeesButton.Text);
        }


    }
}
