


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
        private DocumentType documentTypesPage;
        private IDApprovallevelList iDApprovallevelList;

        public DocumentTypeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            documentTypesPage = scenarioContext["DocumentTypesPage"] as DocumentType ?? throw new NullReferenceException("Document Type Page is NULL.");
        }

        [When(@"I click on Add Document Type button")]
        public void WhenIClickOnAddDocumentTypeButton()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));

            scenarioContext["DocumentTypeDetails"] = documentTypesPage.ClickOnAddDocumentsLink();

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



        [When(@"I click on View approval levels button")]
        public void WhenIClickOnViewApprovalLevelsButton()
        {
            iDApprovallevelList = documentTypesPage.ClickOnViewApprovalLevelsIcon();
            scenarioContext["IDApprovallevelList"] = iDApprovallevelList;

            
        }

        [Then(@"I should be navigated toIDApproval level List Page")]
        public void ThenIShouldBeNavigatedToIDApprovalLevelListPage()
        {
            var IDApprovallevelList = scenarioContext["IDApprovallevelList"] as IDApprovallevelList; 
            Thread.Sleep(100);  
            Assert.IsNotNull(IDApprovallevelList);
            IDApprovallevelList.Wait.Until(ExpectedConditions.ElementToBeClickable(IDApprovallevelList.AddApprovalLevelClick));
           
            Assert.AreEqual("Add Approval level", IDApprovallevelList.AddApprovalLevelClick.Text);            

           
        }

        [When(@"I click on AddApprovalLevelClick button")]
        public void WhenIClickOnAddApprovalLevelClickButton()
        {
            Thread.Sleep(100);  
            var NewDocTypeApprovalLVI = iDApprovallevelList.ClickOnAddApprovallevelLink();
            scenarioContext["NewDocTypeApprovalLVI"] = NewDocTypeApprovalLVI;

        }

    }

}






