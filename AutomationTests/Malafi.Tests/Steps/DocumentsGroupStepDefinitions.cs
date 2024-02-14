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
 /// <summary>
       private IWebDriver driver;
 /// </summary>
        private DocumentsGroup documentsGroupPage;



            public DocumentsGroupStepDefinitions(ScenarioContext context)

       {

            scenarioContext = context;

            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");
        }



        [When(@"I click on Add Document group button")]
        public void WhenIClickOnAddDocumentGroupButton()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;

            Assert.IsNotNull(malafiHome);
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
            scenarioContext["DocumentsGroupForm"] = documentsGroupPage.ClickOnAddDocumentsGroupLink();

        }



        [Then(@"I should be navigated to Add Documents group Page")]
        public void ThenIShouldBeNavigatedToAddDocumentsGroupPage()
        {
            var documentsGroupForm = scenarioContext["DocumentsGroupForm"]as DocumentsGroupForm;
            Assert.IsNotNull(documentsGroupForm);
            documentsGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupForm.ClickOnSaveButton));
 
            Assert.IsTrue(documentsGroupForm.ClickOnSaveButton.Displayed);

        }

    }
}
