using Malafi.Tests.Models;
using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Audits;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private string textEn;
        private string textAr;
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
            textEn = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[2]/span")).Text;
            textAr = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[1]/span")).Text;
        }


        [When(@"I click on add to add the document grope to the employee")]
        public void WhenIClickOnAddToAddTheDocumentGropeToTheEmployee()
        {
            addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[3]/div/button/i")).Click();
            Thread.Sleep(300);
            //\d+\s*to\s*(?<pageCount>\d+)\s*of\s*(?<totalItems>\d+)\s*items
            //Regex.Match(FromScreenTableFooter, "\\d+\\s*to\\s*(?<pageCount>\\d+)\\s*of\\s*(?<totalItems>\\d+)\\s*items").Groups["totalItems"].Value;
            //var numberOfPages = Math.Ceiling(totalItems / 10.0m);
            //for (int j = 0; j < numberOfPages; j++)
            //{
            var assignedDocumentGroupsRows = addQualificationGroupsPage.AssignedDocumentGroups.FindElements(By.XPath("//*[@id='b3-b9-MainContent']/div/table/tbody/tr"));
            for (int i = 0; i < assignedDocumentGroupsRows.Count; i++)
            {
                //    //Key = Title EN
                //    //Value = whole row
                var qualificationGroup = new QualificationGroupModel();
                qualificationGroup.TitleEn = addQualificationGroupsPage.AssignedDocumentGroups.FindElement(By.XPath($"//*[@id='b3-b9-MainContent']/div/table/tbody/tr[{i + 1}]/td[1]/span")).Text;
                qualificationGroup.TitleAr = addQualificationGroupsPage.AssignedDocumentGroups.FindElement(By.XPath($"//*[@id='b3-b9-MainContent']/div/table/tbody/tr[{i + 1}]/td[2]/span")).Text;

                rowsOf2ndTable.Add(qualificationGroup.TitleEn, qualificationGroup);
            }
            //    //Click on the next page j+2
            //}

        }

        [Then(@"I should find the selectd document group moved to employee document group")]
        public void ThenIShouldFindTheSelectdDocumentGroupMovedToEmployeeDocumentGroup()
        {
            addQualificationGroupsPage.Wait.Until(ExpectedConditions.ElementToBeClickable(addQualificationGroupsPage.AddingDocumentGroupButton));

            Assert.IsTrue(rowsOf2ndTable.ContainsKey(textEn));
            Assert.AreEqual(textEn, rowsOf2ndTable[textEn].TitleEn);
            Assert.AreEqual(textAr, rowsOf2ndTable[textEn].TitleAr);
        }





    }
}
