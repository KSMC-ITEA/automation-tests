using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DocumentsGroupStepDefinitions
 {   
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        private DocumentsGroup documentsGroupPage;



            public DocumentsGroupStepDefinitions(ScenarioContext context)

       {

            scenarioContext = context;

            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");
        }

        public DocumentsGroupStepDefinitions()
        {
        }

        [When(@"I click on Add Document group button")]
        public void WhenIClickOnAddDocumentGroupButton()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;

            Assert.IsNotNull(malafiHome);
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
            scenarioContext["DocumentGroupForm"] = documentsGroupPage.ClickOnAddDocumentsGroupLink();

        }



        [Then(@"I should be navigated to Add Documents group Page")]
        public void ThenIShouldBeNavigatedToAddDocumentsGroupPage()
        {
            var documentGroupForm = scenarioContext["DocumentGroupPage"] as DocumentsGroupForm;
            Assert.IsNotNull(documentGroupForm);

            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.ClickOnSaveButton));
            Assert.IsTrue(documentGroupForm.ClickOnSaveButton.Displayed);

        }

    }
}
