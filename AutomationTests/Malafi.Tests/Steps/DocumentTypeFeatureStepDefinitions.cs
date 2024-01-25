


using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DocumentTypeFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        private DocumentType documentTypesPage;

        public DocumentTypeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver;

        }

        [When(@"I click on Add Document Type button")]
        public void WhenIClickOnAddDocumentTypeButton()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));

            scenarioContext["DocumentTypeDetails"] = documentTypesPage.ClickOnAddDocumentsLink();

       //     Thread.Sleep(5000);
        }


        [When(@"Click on Add Document Type button")]
        public void WhenClickOnAddDocumentTypeButton()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));

            scenarioContext["DocumentTypeDetails"] = documentTypesPage.ClickOnAddDocumentsLink();
        }







        [Then(@"I should be navigated to Add Document Types Page")]
        public void ThenIShouldBeNavigatedToAddDocumentTypesPage()
        {
            var addDocumentTypePage = scenarioContext["DocumentTypeDetails"] as DocumentsTypeDetails;
            Assert.IsNotNull(addDocumentTypePage);
            addDocumentTypePage.Wait.Until(ExpectedConditions.ElementToBeClickable(addDocumentTypePage.ClickOnSaveButton1));
            Assert.IsTrue(addDocumentTypePage.ClickOnSaveButton1.Displayed);
        }



    }
}







