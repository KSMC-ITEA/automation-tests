using Malafi.Tests.Features;
using Malafi.Tests.Models;
using Malafi.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static System.Net.Mime.MediaTypeNames;

namespace Malafi.Tests.Steps
{
    [Binding]

    public class RegistrationStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly Registration registrationFormPage;
        private RegistrationData registrationData;

        public RegistrationStepDefinitions(ScenarioContext context)
        {
            this.scenarioContext = context;
            registrationFormPage = scenarioContext["RegistrationForm"] as Registration;

        }


        private void HandleSelectElement(IWebElement element, string textToSelect)
        {
            registrationFormPage.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
            var select = new SelectElement(element);
            select.SelectByText(textToSelect);
        }

        [Given(@"I filled in all the required feilds")]
        public void GivenIFilledInAllTheRequiredFeilds()
        {

            HandleSelectElement(registrationFormPage.NationalityDropDown, registrationData.Nationality);
            HandleSelectElement(registrationFormPage.JobTitleDropDown, registrationData.JobTitle);

            Thread.Sleep(3000);

            HandleSelectElement(registrationFormPage.JobDropdownOrganizationalLevelEn, registrationData.OrganizationalLevelEn);
            HandleSelectElement(registrationFormPage.JobDropdownOrganizationalLevelEn2,registrationData.OrganizationalLevelEn2);

            HandleSelectElement(registrationFormPage.JobGroup,registrationData.JobGroup);

            HandleSelectElement(registrationFormPage.ContractType, registrationData.ContractType);
            HandleSelectElement(registrationFormPage.RequestStatus, registrationData.RequestStatus);




        }

        [Given(@"Entered the following informaion")]
        public void GivenEnteredTheFollowingInformaion(Table table)
        {
            registrationData = table.CreateInstance<RegistrationData>();
        }

        [When(@"Changed the '([^']*)' with the '([^']*)'")]
        public void WhenChangedTheWithThe(string field, string value)
        {
            if (field == "Email")
                registrationData.Email = value;
            else if (field == "Mobile")
                registrationData.Mobile = value;
            else if (field == "Job Number")
                registrationData.jobNumber= value;

        }


        [Then(@"The '([^']*)' validation should have the '([^']*)'")]
        public void ThenTheValidationShouldHaveThe(string field, string message)
        {
            //if (field == "Email")
            //    Assert.AreEqual(registrationFormPage.EmailValidation.Text, message);
            //else if (field == "Mobile")
            //    Assert.AreEqual(registrationFormPage.MobileValidation.Text, message);
            //else if (field == "Job Number")
            //    Assert.AreEqual(registrationFormPage.Job_NumberValidation.Text, message);
            Assert.AreEqual(registrationFormPage.ValidationObjects[field].Text, message);

        }


        [When(@"Clicked on submit button")]
        public void WhenClickedOnSubmitButton()
        {


            registrationFormPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registrationFormPage.SubmitButton)).Click();
            //Thread.Sleep(5000);

        }

        [Then(@"I should See the succuessfully registration message")]
        public void ThenIShouldSeeTheSuccuessfullyRegistrationMessage()
        {
            registrationFormPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registrationFormPage.SuccessMessage));
            Assert.AreEqual("Your request was sent successfully", registrationFormPage.SuccessMessage.Text);
        }


    }
}




    

