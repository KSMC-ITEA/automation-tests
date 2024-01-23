using Malafi.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DocumentsTypeDetailsFeatureStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly IWebDriver? driver;
        private readonly DocumentsTypeDetails? documentTypeDetails;

        public DocumentsTypeDetailsFeatureStepDefinitions(ScenarioContext context)
        {
            this.context = context;
            driver = context["WebDriver"] as IWebDriver;
            documentTypeDetails = context["DocumentTypeDetails"] as DocumentsTypeDetails;
        }
        [Given(@"I completed the form New Document Type")]
        public void GivenICompletedTheFormNewDocumentType(Table table)
        {
            List<TestData> data = table.CreateSet<TestData>().ToList();

            //data.Rows[0]["Title AR"] //Title AR
            //data.Rows[0]["Title EN"] //Title EN
            var titleAR = data[0].TitleAR;


            var titleEN = data[0].TitleEN;
            var WebsiteLink = data[0].WebsiteLink; 
            var OnBaseNumber1 = data[0].OnBaseNumber1;
            var uploadFile1= data[0].uploadFile1;

            Assert.IsNotNull(documentTypeDetails);

            documentTypeDetails.New_Document_Type(titleAR, titleEN, WebsiteLink, OnBaseNumber1, uploadFile1);
        }

        [When(@"I click on save button")]
        public void ThenIClickOnSaveButton()
        {
            Assert.IsNotNull(documentTypeDetails);
            documentTypeDetails.ClickOnSaveButton();
        }

        [Then(@"A successful notification message should be appeared")]
        public void ThenASuccessfulNotificationMessageShouldBeAppeared()
        {
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.SuccessMessage));

            Assert.AreEqual("Data has been added successfully", documentTypeDetails.SuccessMessage.Text);
        }

    }
}
