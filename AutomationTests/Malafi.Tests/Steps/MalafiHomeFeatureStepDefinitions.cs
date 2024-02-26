using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class MalafiHomeFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private DocumentType documentTypesPage;
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
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));
        }

        [Then(@"I should be navigated to Document Types Page")]
        public void ThenIShouldBeNavigatedToDocumentTypesPage()
        {
            Assert.AreEqual("Add Document Type", documentTypesPage.AddDocumentsTypes.Text);
        }


        [When(@"Clicked Documents Group link")]
        public void WhenClickedDocumentsGroupLink()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            malafiHome.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHome.DocumentGroupLink));
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


    }
}
