using Malafi.Tests.Models;
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
        private string search;
        private int rowNumber;
        private RegisteredEmployees registeredEmployeesPage;
        List<EmployeesDataModel> employees;

        public RegisteredEmployeesStepDefinitions(ScenarioContext context)

        {
            scenarioContext = context;
            employees = new List<EmployeesDataModel>();
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



        [Given(@"I write data on the search filed'([^']*)'")]
        public void GivenIWriteDataOnTheSearchFiled(string search)
        {
            this.search = search;
            registeredEmployeesPage = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesPage);
            registeredEmployeesPage.SearchField.SendKeys(search);


        }

        [When(@"I prepare the employee data")]
        public void WhenIPrepareTheEmployeeData()
        {


            var employeesTableRows = registeredEmployeesPage.EmployeeTable.FindElements(By.XPath("//*[@id='b3-b1-MainContent']/div/table/tbody/tr"));
            // 
            for (int i = 0; i < employeesTableRows.Count; i++)
            {
                //    //Key = Title EN
                //    //Value = whole row
                var employeeData = new EmployeesDataModel();
                employeeData.EmployeeName = registeredEmployeesPage.EmployeeTable.FindElement(By.XPath($"//*[@id='b3-b1-MainContent']/div/table/tbody/tr[{i + 1}]/td[1]/span")).Text;
                employeeData.EmployeeID = registeredEmployeesPage.EmployeeTable.FindElement(By.XPath($"//*[@id='b3-b1-MainContent']/div/table/tbody/tr[{i + 1}]/td[2]/span")).Text;
                employees.Add(employeeData);


            }
        }

        [Then(@"data in the grid should be filterd with row contain the search key '([^']*)'")]
        public void ThenDataInTheGridShouldBeFilterdWithRowContainTheSearchKey(string searchKey)
        {
            bool IsContain = employees.All(e => e.EmployeeName.Contains(searchKey) || e.EmployeeID.Contains(searchKey));
            Assert.IsTrue(IsContain);

        }






    }


}

