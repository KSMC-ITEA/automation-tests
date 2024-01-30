using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Malafi.Tests.Steps
{

    [Binding]
    public class DocumentsTypeDetailsFeatureStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly DocumentsTypeDetails documentTypeDetails;
        private TestData testData;

        public DocumentsTypeDetailsFeatureStepDefinitions(ScenarioContext context)
        {
            this.context = context;
            documentTypeDetails = context["DocumentTypeDetails"] as DocumentsTypeDetails ?? throw new NullReferenceException();
        }
        [Given(@"I completed the form New Document Type")]
        public void GivenICompletedTheFormNewDocumentType(Table table)
        {
            TestData data = table.CreateInstance<TestData>();

            testData = data;
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.TitleAr));

        }

        [When(@"I click on save button")]
        public void ThenIClickOnSaveButton()
        {
            documentTypeDetails.AddNewDocumentType(testData);
        }

        [Then(@"A successful notification message should be appeared")]
        public void ThenASuccessfulNotificationMessageShouldBeAppeared()
        {
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.FeedbackMessage));

            Assert.AreEqual("Data has been added successfully", documentTypeDetails.FeedbackMessage.Text);
        }

        [When(@"I enter '([^']*)' in '([^']*)'")]
        public void WhenIEnterIn(string text, string field)
        {
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.TitleAr));


            if (field == "Title Ar")
            {
                testData.TitleAR = text;
            }
            else if (field == "Title En")
            {
                testData.TitleEN = text;
            }
        }

        [Then(@" A validation message should be appeared")]
        public void ThenAValidationMessageShouldBeAppeared()
        {
            Assert.AreEqual("Data has been added successfully", documentTypeDetails.FeedbackMessage.Text);
        }


        [Then(@"An error message notification message should be appeared")]
        public void ThenAErrorMessageNotificationMessageShouldBeAppeared()
        {
            documentTypeDetails.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypeDetails.FeedbackMessage));
            Assert.AreEqual("Can't Save document Types because some fields have errors", documentTypeDetails.FeedbackMessage.Text);
        }

    }
}
