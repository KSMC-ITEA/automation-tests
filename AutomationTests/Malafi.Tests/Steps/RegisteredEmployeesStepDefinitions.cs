using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class RegisteredEmployeesStepDefinitions
    {
        private ScenarioContext scenarioContext;

        private ReviewEmployeeRequest reviewEmployeeRequestPage;
        private AddQualificationGroups addQualificationGroupsPage;
        public RegisteredEmployeesStepDefinitions(ScenarioContext context)

        {
            scenarioContext = context;
        }

        [When(@"I Click on '([^']*)' link")]
        public void WhenIClickOnLink(string empStatus)
        {
            var registeredEmployeesPage = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesPage);
            registeredEmployeesPage.GiveTheSelectedStatus(empStatus);
            scenarioContext["EmpStatus"] = empStatus;
        }

        [When(@"I click click on review button")]
        public void WhenIClickClickOnReviewButton()
        {

            var registeredEmployeesPage = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesPage);

            if (scenarioContext["EmpStatus"].ToString().Equals("Approved"))
            {
                registeredEmployeesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesPage.ApprovedReviewButton));
                reviewEmployeeRequestPage = registeredEmployeesPage.ClickOnApprovedReviewButton();
            }
            else
            {
                registeredEmployeesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesPage.ReviewButton));
                reviewEmployeeRequestPage = registeredEmployeesPage.ClickOnReviewButton();
            }
            scenarioContext["ReviewEmployeeRequest"] = reviewEmployeeRequestPage;
            Thread.Sleep(500);
        }

        public void GivenIClickClickOnApprovedReviewButton()
        {

            var registeredEmployeesPage = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesPage);
            reviewEmployeeRequestPage = registeredEmployeesPage.ClickOnApprovedReviewButton();
            scenarioContext["ReviewEmployeeRequest"] = reviewEmployeeRequestPage;
            Thread.Sleep(500);
        }
        /// <summary>
        /// in reviw
        /// </summary>
        ///       
        /// 

        [Given(@"I click on Approved status")]
        public void GivenIClickOnApprovedStatus()
        {
            var registeredEmployeesPage = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesPage);
            registeredEmployeesPage.GiveTheApprovedEmployees();
            registeredEmployeesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesPage.AddButton));
        }

        [When(@"I click on add icon for any employee")]
        public void GivenIClickOnAddIconForAnyEmployee()
        {
            var registeredEmployeesPage = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesPage);
            addQualificationGroupsPage = registeredEmployeesPage.ClickOnAddIcon();
            scenarioContext["AddQualificationGroups"] = addQualificationGroupsPage;
            addQualificationGroupsPage.Wait.Until(ExpectedConditions.ElementToBeClickable(addQualificationGroupsPage.AddingDocumentGroupButton));
        }












    }
}
