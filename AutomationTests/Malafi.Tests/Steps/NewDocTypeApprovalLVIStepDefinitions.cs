using Malafi.Tests.Pages;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class NewDocTypeApprovalLVIStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly NewDocTypeApprovalLVI NewDocTypeApprovalLVI;

        public NewDocTypeApprovalLVIStepDefinitions(ScenarioContext context)
        {
            this.context = context;
            NewDocTypeApprovalLVI = context["NewDocTypeApprovalLVI"] as NewDocTypeApprovalLVI ?? throw new NullReferenceException();
        }


        [Given(@"I completed the form New Document LVI")]
        public void GivenICompletedTheFormNewDocumentLVI()
        {
            
            NewDocTypeApprovalLVI.AddNewDocumentLVI();
            NewDocTypeApprovalLVI.Wait.Until(ExpectedConditions.ElementToBeClickable(NewDocTypeApprovalLVI.AssignedToTypeBox));
            var select = new SelectElement(NewDocTypeApprovalLVI.AssignedToTypeBox);
            select.SelectByText("Employee");
            NewDocTypeApprovalLVI.Wait.Until(ExpectedConditions.ElementToBeClickable(NewDocTypeApprovalLVI.EmployeeBox)).Click();
            NewDocTypeApprovalLVI.Wait.Until(ExpectedConditions.ElementToBeClickable(NewDocTypeApprovalLVI.Employee)).Click();

        }

        [When(@"I click save button")]
        public void WhenIClickSaveButton()
        {
            Thread.Sleep(300);
            NewDocTypeApprovalLVI.ClickSave();
        }


        [Then(@"A Successful Notification Message Should Be Appeared")]
        public void ThenASuccessfulNotificationMessageShouldBeAppeared()
        {
            NewDocTypeApprovalLVI.Wait.Until(ExpectedConditions.ElementToBeClickable(NewDocTypeApprovalLVI.FeedbackMessage));

            Assert.AreEqual("Data has been added successfully", NewDocTypeApprovalLVI.FeedbackMessage.Text);
        }


        [Then(@"A ErrorMessage Notification Message Should Be Appeared")]
        public void ThenAErrorMessageNotificationMessageShouldBeAppeared()
        {
            NewDocTypeApprovalLVI.Wait.Until(ExpectedConditions.ElementToBeClickable(NewDocTypeApprovalLVI.FeedbackMessage));

            Assert.AreEqual("Can't Save document Types because some fields have errors", NewDocTypeApprovalLVI.FeedbackMessage.Text);
        }

    }
}
