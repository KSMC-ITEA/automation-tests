using Malafi.Tests.Models;
using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Audits;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace Malafi.Tests.Steps
{
    [Binding]

    public class AddQualificationGroupsStepDefinitions

    {
        private ScenarioContext scenarioContext;

        private AddQualificationGroups addQualificationGroupsPage;
        private IWebElement randomRow;
        private string textEn;
        private string textAr;
        private string randomRowText;
        private int rowNumber;
        Dictionary<string, QualificationGroupModel> rowsOf2ndTable;



        public AddQualificationGroupsStepDefinitions(ScenarioContext context)

        {

            scenarioContext = context;

            addQualificationGroupsPage = scenarioContext["AddQualificationGroups"] as AddQualificationGroups;
            rowsOf2ndTable = new Dictionary<string, QualificationGroupModel>();
        }





        [Given(@"I prepare the Document data")]
        public void GivenIPrepareTheDocumentData()
        {
            addQualificationGroupsPage.Wait.Until(ExpectedConditions.ElementToBeClickable(addQualificationGroupsPage.AddingDocumentGroupButton));
            var numberOfRows = addQualificationGroupsPage.DocumentsGroupTable.FindElements(By.XPath("//*[@id='b3-b7-MainContent']/div/table/tbody/tr")).Count;
            rowNumber = Random.Shared.Next(1, numberOfRows);// 0 -> numberOfRows
            randomRow = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath("//*[@id='b3-b7-MainContent']/div/table/tbody/tr[" + rowNumber + "]"));
            textEn = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[2]/span")).Text;
            textAr = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[1]/span")).Text;
            randomRowText = randomRow.Text;

        }


        [When(@"I click on add to add the document grope to the employee")]
        public void WhenIClickOnAddToAddTheDocumentGropeToTheEmployee()
        {
            addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[3]/div/button/i")).Click();
            Thread.Sleep(300);
            var assignedDocumentGroupsRows = addQualificationGroupsPage.AssignedDocumentGroups.FindElements(By.XPath("//*[@id='b3-b9-MainContent']/div/table/tbody/tr"));
            //foreach (var row in assignedDocumentGroupsRows)
            //{
            //    //Key = Title EN
            //    //Value = whole row
            //    var key = row.Text;
            //    rowsOf2ndTable.Add(key, row);
            //}
            for (int i = 0; i < assignedDocumentGroupsRows.Count; i++)
            {
                //    //Key = Title EN
                //    //Value = whole row
                var qualificationGroup = new QualificationGroupModel();
                qualificationGroup.TitleEn = addQualificationGroupsPage.AssignedDocumentGroups.FindElement(By.XPath($"//*[@id='b3-b9-MainContent']/div/table/tbody/tr[{i + 1}]/td[1]/span")).Text;
                qualificationGroup.TitleAr = addQualificationGroupsPage.AssignedDocumentGroups.FindElement(By.XPath($"//*[@id='b3-b9-MainContent']/div/table/tbody/tr[{i + 1}]/td[2]/span")).Text;

                var key = assignedDocumentGroupsRows[i].Text;
                rowsOf2ndTable.Add(key, qualificationGroup);
            }
        }

        [Then(@"I should find the selectd document group moved to employee document group")]
        public void ThenIShouldFindTheSelectdDocumentGroupMovedToEmployeeDocumentGroup()
        {
            addQualificationGroupsPage.Wait.Until(ExpectedConditions.ElementToBeClickable(addQualificationGroupsPage.AddingDocumentGroupButton));

            Assert.IsTrue(rowsOf2ndTable.ContainsKey(randomRowText));
            Assert.AreEqual(textEn, rowsOf2ndTable[randomRowText].TitleEn);
            Assert.AreEqual(textAr, rowsOf2ndTable[randomRowText].TitleAr);
        }





    }
}
