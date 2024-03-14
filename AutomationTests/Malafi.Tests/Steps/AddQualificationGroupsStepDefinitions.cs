using Malafi.Tests.Models;
using Malafi.Tests.Pages;
using OpenQA.Selenium;

using SeleniumExtras.WaitHelpers;

using System.Text.RegularExpressions;


using TechTalk.SpecFlow;






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
            var rows = addQualificationGroupsPage.DocumentsGroupTable.FindElements(By.XPath("//*[@id='b3-b7-MainContent']/div/table/tbody/tr"));
            rowNumber = Random.Shared.Next(1, rows.Count);// 0 -> numberOfRows
            textEn = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[2]/span")).Text;
            textAr = addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[1]/span")).Text;
        }


        [When(@"I click on add to add the document grope to the employee")]
        public void WhenIClickOnAddToAddTheDocumentGropeToTheEmployee()
        {
            addQualificationGroupsPage.DocumentsGroupTable.FindElement(By.XPath($"//*[@id='b3-b7-MainContent']/div/table/tbody/tr[{rowNumber}]/td[3]/div/button/i")).Click();
            Thread.Sleep(300);

            // item ber page,total of items in all pages 
            //@ all back slahes are sckiped 
            var pattern = @"(?<pageStart>\d+)\s*to\s*(?<pageEnd>\d+)\s*of\s*(?<totalItems>\d+)\s*items";
            var matches = Regex.Match(addQualificationGroupsPage.TableFooter.Text, pattern);
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Success);
            int pageStart = int.Parse(matches.Groups["pageStart"].Value);
            int pageEnd = int.Parse(matches.Groups["pageEnd"].Value);
            int totalItems = int.Parse(matches.Groups["totalItems"].Value);
            // celing mean faction number mean the next number
            int numberOfPages = (int)Math.Ceiling(totalItems / (pageEnd - pageStart + 1.0m));

            ///// var numberOfPages = Math.Ceiling(totalItems / 10.0m);
            for (int j = 0; j < numberOfPages; j++)
            {
                // document group in the scond table
                var assignedDocumentGroupsRows = addQualificationGroupsPage.AssignedDocumentGroups.FindElements(By.XPath("//*[@id='b3-b9-MainContent']/div/table/tbody/tr"));
                // 
                for (int i = 0; i < assignedDocumentGroupsRows.Count; i++)
                {
                    //    //Key = Title EN
                    //    //Value = whole row
                    var qualificationGroup = new QualificationGroupModel();
                    qualificationGroup.TitleEn = addQualificationGroupsPage.AssignedDocumentGroups.FindElement(By.XPath($"//*[@id='b3-b9-MainContent']/div/table/tbody/tr[{i + 1}]/td[1]/span")).Text;
                    qualificationGroup.TitleAr = addQualificationGroupsPage.AssignedDocumentGroups.FindElement(By.XPath($"//*[@id='b3-b9-MainContent']/div/table/tbody/tr[{i + 1}]/td[2]/span")).Text;
                    // we use dic to we test specfic value(retrive)
                    rowsOf2ndTable.Add(qualificationGroup.TitleEn, qualificationGroup);
                }
                if (!addQualificationGroupsPage.NextPage.Enabled)
                {
                    break;
                }

                addQualificationGroupsPage.NextPage.Click();
                Thread.Sleep(300);

            }

        }

        [Then(@"I should find the selectd document group moved to employee document group")]
        public void ThenIShouldFindTheSelectdDocumentGroupMovedToEmployeeDocumentGroup()
        {
            addQualificationGroupsPage.Wait.Until(ExpectedConditions.ElementToBeClickable(addQualificationGroupsPage.AddingDocumentGroupButton));
            // check if name is added
            Assert.IsTrue(rowsOf2ndTable.ContainsKey(textEn));
            //check if the name is correct
            Assert.AreEqual(textEn, rowsOf2ndTable[textEn].TitleEn);
            Assert.AreEqual(textAr, rowsOf2ndTable[textEn].TitleAr);
        }





    }
}
