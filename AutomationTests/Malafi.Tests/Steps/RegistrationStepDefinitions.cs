using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly Registration registrationFormPage;

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
                        
            HandleSelectElement(registrationFormPage.NationalityDropDown, "China");
            HandleSelectElement(registrationFormPage.JobtitleDropDown, "Casher");

            Thread.Sleep(3000);

            HandleSelectElement(registrationFormPage.JobDropdownOrganizationalLevelEn, "Administration");
            HandleSelectElement(registrationFormPage.JobDropdownOrganizationalLevelEn2, "Infection Control");
             
            HandleSelectElement(registrationFormPage.JobGroup, "Technician");

            HandleSelectElement(registrationFormPage.ContractType, "MOH");

        }

       
        [When(@"Clicked on submit button")]
        public void WhenClickedOnSubmitButton()
        {


            registrationFormPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registrationFormPage.SubmitButton)).Click();
            Thread.Sleep(5000);
           
        }

        [Then(@"I should See the succuessfully registration message")]
        public void ThenIShouldSeeTheSuccuessfullyRegistrationMessage()
        {
            throw new PendingStepException();

        }
    }
}
