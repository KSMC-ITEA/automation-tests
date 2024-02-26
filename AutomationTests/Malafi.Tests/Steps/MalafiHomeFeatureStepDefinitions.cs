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
        private IWebDriver driver;
        private DocumentType documentTypesPage;
        private Pages.EmployeesSearch employeesSearch;
        private RegisteredEmployees registeredEmployees;
        private Dashboards dashboards;

        private DocumentsGroup documentsGroupPage;
        private MalafiHome malafiHomePage;

        public MalafiHomeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            malafiHomePage = scenarioContext["MalafiHome"] as MalafiHome ?? throw new NullReferenceException("Malafi Home is null");
        }

        [When(@"click on Request a Registration link")]
        public void WhenClickOnRequestARegistrationLink()
        {
            malafiHomePage.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHomePage.RequestReistrationButton));
            var registrationFormPage = malafiHomePage.ClickOnRegistrationFormButton();
            scenarioContext["RegistrationForm"] = registrationFormPage;
        }

        [Then(@"I should be navigated to Employee Registration Form")]
        public void ThenIShouldBeNavigatedToEmployeeRegistrationForm()
        {
            var registrationFormPage = scenarioContext["RegistrationForm"] as Registration;
            registrationFormPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registrationFormPage.SubmitButton));
            Assert.AreEqual("Submit", registrationFormPage.SubmitButton.Text);
        }
        [When(@"click on Edit a Registration link")]
        public void WhenClickOnEditARegistrationLink()
        {
            var registrationFormPage = malafiHomePage.ClickOnRegistrationFormButton();
            scenarioContext["RegistrationForm"] = registrationFormPage;
        }
        [Then(@"I should be navigated to Employee Edit Registration Form")]
        public void ThenIShouldBeNavigatedToEmployeeEditRegistrationForm()
        {
            var registrationFormPage = scenarioContext["RegistrationForm"] as Registration;
            registrationFormPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registrationFormPage.SubmitButton));
            Assert.AreEqual("Submit", registrationFormPage.SubmitButton.Text);
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
            malafiHome.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHome.DocumentGroupLink));
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
            scenarioContext["DocumentsGroupForm"] = documentsGroupPage;
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
        }

        [Then(@"I should be navigated to Documents Group Page")]
        public void ThenIShouldBeNavigatedToDocumentsGroupPage()
        {
            Assert.AreEqual("Add Documents Group", documentsGroupPage.AddDocumentsGroupButton.Text);
        }

        [When(@"Clicked Registered Employees link")]
        public void WhenClickedRegisteredEmployeesLink()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            scenarioContext["registeredEmployees"] = registeredEmployees;

            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();

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


    }
}
