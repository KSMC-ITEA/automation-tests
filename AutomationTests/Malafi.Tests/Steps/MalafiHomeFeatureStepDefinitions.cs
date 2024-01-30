using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class MalafiHomeFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private DocumentType documentTypesPage;
        private MalafiHome malafiHomePage;

        public MalafiHomeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            malafiHomePage = scenarioContext["MalafiHome"] as MalafiHome ?? throw new NullReferenceException("Malafi Home is null");
        }

        [When(@"click on Request a Registration link")]
        public void WhenClickOnRequestARegistrationLink()
        {
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


        [When(@"I clicked DocumentsTypes link")]
        public void WhenIClickedDocumentsTypesLink()
        {
            documentTypesPage = malafiHomePage.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.Add_Documents_Types));
        }

        [Then(@"I should be navigated to Document Types Page")]
        public void ThenIShouldBeNavigatedToDocumentTypesPage()
        {
            Assert.AreEqual("Add Document Type", documentTypesPage.Add_Documents_Types.Text);
        }
    }
}
