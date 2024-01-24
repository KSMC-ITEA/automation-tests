using Malafi.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Reflection.Emit;
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

        String WebsiteLink2;
        String OnBaseNumber2;
        String uploadFile2;
        String titleAR2;
        String titleEN2;

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

             WebsiteLink2=data[0].WebsiteLink;
             OnBaseNumber2 = data[0].OnBaseNumber1;
             uploadFile2 = data[0].uploadFile1;
             titleAR2 = data[0].TitleAR;
             titleEN2 = data[0].TitleEN;





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

        [When(@"I enter '([^']*)' in '([^']*)'")]
        public void WhenIEnterIn(string text, string field)
        {
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.TitleAr));

            //data.Rows[0]["Title AR"] //Title AR
            //data.Rows[0]["Title EN"] //Title EN


            if (field == "Title Ar")
            {
                documentTypeDetails.New_Document_Type(text, titleEN2, WebsiteLink2, OnBaseNumber2, uploadFile2);
            }
            else if (field == "Title En")
            {
                documentTypeDetails.New_Document_Type(titleAR2, text, WebsiteLink2, OnBaseNumber2, uploadFile2);
            }
            Thread.Sleep(5000);
        }

        [Then(@"A validation message should appar")]
        public void ThenAValidationMessageShouldAppar()
        {
            Assert.IsNotNull(documentTypeDetails.SuccessMessage);
            

        }


        [Then(@"A ErrorMessage notification message should be appeared")]
        public void ThenAErrorMessageNotificationMessageShouldBeAppeared()
        {
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.ErrorMessage));

            Assert.AreEqual("Can't Save document Types because some fields have errors", documentTypeDetails.ErrorMessage.Text);

        }






    }
}
