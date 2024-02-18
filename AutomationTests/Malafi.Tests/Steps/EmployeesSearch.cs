using ClosedXML.Excel;
using Malafi.Tests.Pages;
using Malafi.Tests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class EmployeesSearch
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        private RegisteredEmployees registeredEmployeesReview;
        private Pages.EmployeesSearch employeesSearch;

        public EmployeesSearch(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");

        }

        [When(@"I click on  Excel  button")]
        public void WhenIClickOnReviewButton()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);

            malafiHome.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHome.EmployeesSearchLink));
            Thread.Sleep(100);
            employeesSearch = malafiHome.ClickOnEmployeesSearch();
            employeesSearch.Wait.Until(ExpectedConditions.ElementToBeClickable(employeesSearch.Excel)).Click();
            scenarioContext["RegisteredEmployees"] = registeredEmployeesReview;
            Thread.Sleep(6000);
        }
     

        [When(@"I click on  Employee Name Changing the name")]
        public void WhenIClickOnEmployeeNameChangingTheName()
        {
            registeredEmployeesReview = scenarioContext["RegisteredEmployees"] as RegisteredEmployees;
            Assert.IsNotNull(registeredEmployeesReview);

            registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.EmployeeName)).Click();
        }
        [When(@"I click on Save Changes")]
        public void WhenIClickOnSaveChanges()
        {
            registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.SaveChanges)).Click();

            registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.SaveChangesPopup)).Click();
        }

        [Then(@"It is supposed to be for readers only")]
        public void ThenItIsSupposedToBeForReadersOnly()
        {
            Thread.Sleep(1000);

            Assert.IsFalse(registeredEmployeesReview.EmployeeName.Enabled);
        }

        [Then(@"I should be navigated to  Excel  form")]
        public void ThenIShouldBeNavigatedToExcelForm()
        {
            var empDataFile = ExcelManipulation.GetDownloadedFile("EmployeesData");
            var workSheet = empDataFile.Worksheets.FirstOrDefault();
            IXLRow selectedRow = null;
            var firstRow = employeesSearch.EmployeesTable.FindElement(By.XPath("//tbody/tr[1]"));
            foreach (var row in workSheet.Rows())
            {
           
                    if (row.Cells("1").FirstOrDefault().GetText() == firstRow.FindElement(By.XPath("//td[1]")).Text)
                    {
                        selectedRow = row; 
                        break;
                    }
            }

            Assert.IsNotNull(selectedRow);
            //Employee Name
            Assert.AreEqual(firstRow.FindElement(By.XPath("//td[1]")).Text, selectedRow.Cells("1")?.FirstOrDefault()?.GetText());
            //Job Number
            Assert.AreEqual(firstRow.FindElement(By.XPath("//td[2]")).Text, selectedRow.Cells("8")?.FirstOrDefault()?.GetText());
            //National ID
            Assert.AreEqual(firstRow.FindElement(By.XPath("//td[3]")).Text, selectedRow.Cells("17")?.FirstOrDefault()?.GetText());
        }
    }
}
