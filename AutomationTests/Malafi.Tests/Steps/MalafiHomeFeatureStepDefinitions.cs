using DocumentFormat.OpenXml.Drawing;
using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class MalafiHomeFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private DocumentType documentTypesPage;
        private EmployeesSearch employeesSearch;
        private RegisteredEmployees registeredEmployees;
        private Dashboards dashboards;
        private MyFiles myfiles;
        private Inbox inbox;
        private DocumentsGroup documentsGroupPage;
        private RegisteredEmployees registeredEmployeesPage;
        public MalafiHomeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;

        }
        [When(@"Clicked DocumentsTypes link")]
        public void WhenIClickedDocumentsTypesLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            scenarioContext["DocumentTypesPage"] = documentTypesPage;
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));
        }

        [Then(@"I should be navigated to Document Types Page")]
        public void ThenIShouldBeNavigatedToDocumentTypesPage()
        {
            Assert.AreEqual("Add Document Type", documentTypesPage.AddDocumentsTypes.Text);
        }

        [When(@"Clicked Employees Search link")]
        public void WhenClickedEmployeesSearchlink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            Thread.Sleep(1100);
            employeesSearch = malafiHome.ClickOnEmployeesSearch();
            employeesSearch.Wait.Until(ExpectedConditions.ElementToBeClickable(employeesSearch.EmployeesSearchVLD));
        }

        [Then(@"I should be navigated to Employees Search Page")]
        public void ThenIShouldBeNavigatedToEmployeesSearchPage()
        {
            Assert.AreEqual("Name", employeesSearch.EmployeesSearchVLD.Text);

        }



        [When(@"Clicked Documents Group link")]
        public void WhenClickedDocumentsGroupLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
            // this step give key dictionary for the page calss (key hashing)
            scenarioContext["DocumentsGroupForm"] = documentsGroupPage;
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
        }

        [Then(@"I should be navigated to Documents Group Page")]
        public void ThenIShouldBeNavigatedToDocumentsGroupPage()
        {
            Assert.AreEqual("Add Documents Group", documentsGroupPage.AddDocumentsGroupButton.Text);
        }

        [When(@"Clicked My files link")]
        public void WhenClickedInboxLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            myfiles = malafiHome.ClickOnMyFiles();
            scenarioContext["myfiles"] = myfiles;
        }

        [Then(@"I should be navigated to My files Page")]
        public void ThenIShouldBeNavigatedToInboxPage()
        {
            Thread.Sleep(1000);
            Assert.AreEqual("Document Types For Each Job Role", myfiles.MyFilesVLD.Text);

        }

        [Then(@"I should be navigated to My inbox Page")]
        public void ThenIShouldBeNavigatedToMyInboxPage()
        {
            Thread.Sleep(1000);
            Assert.AreEqual("Documents Needs To Be Reviewd By You", inbox.VLD.Text);
        }





        [When(@"Click on inbox link")]
        public void WhenClickOnInboxLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            inbox = malafiHome.ClickOnInbox();
            scenarioContext["inbox"] = inbox;
        }


        [Then(@"I have been navigated to the approved inbox")]
        public void ThenIhavebeennavigatedtotheapprovedinbox()
        {
            inbox.ClickButtonApprove();
        }

        [When(@"Click on  Reject the Documents")]
        public void WhenClickOnRejectTheDocuments()
        {
            inbox.ClickButtonReject();
        }

        [Then(@"Add Rejection Reason")]
        public void ThenAddRejectionReason()
        {
            Thread.Sleep(1000);

            inbox.Wait.Until(ExpectedConditions.ElementToBeClickable(inbox.ButtonReject)).Click();

            Thread.Sleep(1000);
        }




        [When(@"Clicked Registered Employees link")]
        public void WhenClickedRegisteredEmployeesLink()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);

            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();
            scenarioContext["RegisteredEmployees"] = registeredEmployees;
            Thread.Sleep(300);
        }

        [Then(@"I should be navigated to Registered Employees Page")]
        public void ThenIShouldBeNavigatedToRegisteredEmployeesPage()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();

            Assert.AreEqual("Approved", registeredEmployees.Approved.Text);


        }


        [Given(@"I click on Dashboard")]
        public void GivenIClickOnDashboard()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            dashboards = malafiHome.ClickOnExecutiveDashboard();

        }

        [Then(@"I shoed see Executive Dashboard")]
        public void ThenIShoedSeeExecutiveDashboard()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            Thread.Sleep(300);
            int approved = int.Parse(dashboards.ApprovedEmployees.Text);
            int pending = int.Parse(dashboards.PendingEmployees.Text);
            int rejected = int.Parse(dashboards.RejectedEmployees.Text);
            Assert.AreEqual((approved + pending + rejected).ToString(), dashboards.AlRegisteredEmployees.Text);

        }


        [When(@"Click on Edit")]
        public void WhenClickOnEdit()
        {
            Thread.Sleep(1000);

            inbox.edit.Click();
        }

        [Then(@"The new information must be saved")]
        public void ThenTheNewInformationMustBeSaved()
        {
            inbox.ClickButtonEdit();
        }



        [Then(@"Check Display the Documents for Each Request")]
        public void ThenCheckDisplayTheDocumentsForEachRequest()
        {
            Thread.Sleep(700);
            Assert.AreEqual("Emp User", inbox.EmpUser.Text);
            Assert.AreEqual("Expiry Date(Hijri)", inbox.ExpiryDate.Text);
            Assert.AreEqual("Status", inbox.Status.Text);

        }








    }
}
