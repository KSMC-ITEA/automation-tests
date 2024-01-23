


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
        private IWebDriver? driver;
        private DocumentType documentTypesPage;
        private DocumentsTypeDetails DocumentsTypeDetailsPage;
        public DocumentTypeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver;

        }

        [Given(@"I click on Add Document Type button")]
        public void GivenIClickOnAddDocumentTypeButton()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.Add_Documents_Types));

            scenarioContext["DocumentTypeDetails"] = documentTypesPage.Add_Documents();

       //     Thread.Sleep(5000);
        }


    }
}







