using Malafi.Tests.Pages;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static System.Net.Mime.MediaTypeNames;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DocumentsGroupFormStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly DocumentsGroupForm documentGroupForm;
        private DocumentGroupTestData testData;

        public DocumentsGroupFormStepDefinitions(ScenarioContext context)
        {
         


            this.context = context;
            // retreive the value that map this key of the class(casting,unboxing)
            documentGroupForm = context["DocumentsGroupForm"] as DocumentsGroupForm ?? throw new NullReferenceException();
        }

        [Given(@"I completed the form New Document Group")]
        public void GivenICompletedTheFormNewDocumentGroup(Table table)
        {
            DocumentGroupTestData data = table.CreateInstance<DocumentGroupTestData>();

            testData = data;
            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.ArInputField));
        }

        [When(@"I click on  add document group save button")]
        public void WhenIClickOnAddDocumentGroupSaveButton()
        {
            documentGroupForm.AddNewDocumentGroup(testData);
        }

        [Then(@"A successful message should be appeared")]
        public void ThenASuccessfulMessageShouldBeAppeared()
        {
            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.FeedbackMessage));

            Assert.AreEqual("Data has been added successfully", documentGroupForm.FeedbackMessage.Text);
        }

        [Then(@"A fill message should be appeared")]
        public void ThenAFillMessageShouldBeAppeared()
        {
            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.FeedbackMessage));

            Assert.AreEqual("Names that have already been used cannot be used.", documentGroupForm.FeedbackMessage.Text);
       
        
        
        }

        [Given(@"I enter '([^']*)' in '([^']*)'")]
        public void GivenIEnterIn(string text, string field)
        {
            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.ClickOnSaveButton));

            // if I test the arabic field take the value of english filed from the given and And vice versa
            if (field == "Title Ar")
            {
                testData.TitleAR = text;
            }
            else if (field == "Title En")
            {
                testData.TitleEN = text;
            }
        }

        [Then(@"A ErrorMessage notification message should be appeare")]
        public void ThenAErrorMessageNotificationMessageShouldBeAppeare()
 {
            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.FeedbackMessage));
            Assert.AreEqual("Can't Save document Types because some fields have errors", documentGroupForm.FeedbackMessage.Text);
          
        }




     

    }
}

