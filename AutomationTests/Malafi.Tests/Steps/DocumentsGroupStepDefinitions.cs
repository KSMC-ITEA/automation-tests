using Malafi.Tests.Models;
using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;


namespace Malafi.Tests.Steps
{

    [Binding]
    public class DocumentsGroupStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private DocumentsGroup documentsGroupPage;

        public object MessageBox { get; private set; }

        public DocumentsGroupStepDefinitions(ScenarioContext context)

        {

            scenarioContext = context;

            documentsGroupPage = scenarioContext["DocumentsGroupForm"] as DocumentsGroup;
        }

        public DocumentsGroupStepDefinitions()
        {
        }

        [When(@"I click on Add Document group button")]
        public void WhenIClickOnAddDocumentGroupButton()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;

            Assert.IsNotNull(malafiHome);
            documentsGroupPage = malafiHome.ClickOnDocumentGroupLink();
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.AddDocumentsGroupButton));
            scenarioContext["DocumentGroupForm"] = documentsGroupPage.ClickOnAddDocumentsGroupLink();

        }



        [Then(@"I should be navigated to Add Documents group Page")]
        public void ThenIShouldBeNavigatedToAddDocumentsGroupPage()
        {
            var documentGroupForm = scenarioContext["DocumentGroupForm"] as DocumentsGroupForm;
            Assert.IsNotNull(documentGroupForm);

            documentGroupForm.Wait.Until(ExpectedConditions.ElementToBeClickable(documentGroupForm.ClickOnSaveButton));
            Assert.IsTrue(documentGroupForm.ClickOnSaveButton.Displayed);

        }

        [Given(@"QualificationGroupsList page was opened")]
        public void GivenQualificationGroupsListPageWasOpened()
        {
            throw new PendingStepException();
        }



        [Then(@"I should find Search engine")]
        public void ThenIShouldFindSearchEngine()
        {
            if (documentsGroupPage.SearchEngine.Displayed)
            {
                //return;
                Console.WriteLine("searchEngine found");
            }
            else
            {
                Console.WriteLine("SearchEngine Not found");

            }
        }

        [Then(@"I should find Button named \+ Add documents Group")]
        public void ThenIShouldFindButtonNamedAddDocumentsGroup()
        {
            if (documentsGroupPage.AddDocumentsGroupButton.Displayed)
            {
                return;
            }



        }
        [When(@"I should find the table")]
        public void GivenIShouldFindTheTable()
        {
            //documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeSelected(documentsGroupPage.table));
            Assert.IsTrue(documentsGroupPage.table.Displayed);


        }

        [When(@"I clcick on the header of the first column")]
        public void WhenIClcickOnTheHeaderOfTheFirstColumn()
        {
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.Column1)).Click();
        }


        [Then(@"I should see the elements sorted")]
        public void ThenIShouldSeeTheElementsSorted()
        {
            //documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentsGroupPage.Column1)).Click();
            //Assert.AreEqual(XmlSortOrder.Ascending, documentsGroupPage.Column1.FindElements);
            var rows = documentsGroupPage.table.FindElements(By.XPath("//*[@id='b3-b1-MainContent']/div/table/tbody/tr"));
            List<DocumentGroupItem> list = new List<DocumentGroupItem>();
            string footerText = documentsGroupPage.TableFooter.Text;
            var matches = Regex.Match(footerText, "(?<pageStart>\\d+)\\s*to\\s*(?<pageEnd>\\d+)\\s*of\\s*(?<totalItems>\\d+)\\s*items");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Success);
            int pageStart = int.Parse(matches.Groups["pageStart"].Value);
            int pageEnd = int.Parse(matches.Groups["pageEnd"].Value);
            int totalItems = int.Parse(matches.Groups["totalItems"].Value);

            int numberOfPages = (int)Math.Ceiling(totalItems / (pageEnd - pageStart + 1.0m));
            for (int page = 0; page < numberOfPages; page++)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    DocumentGroupItem data = new DocumentGroupItem();

                    data.Title = rows[i].FindElement(By.XPath($"//*[@id='b3-b1-MainContent']/div/table/tbody/tr[{i + 1}]/td[1]")).Text;
                    data.CreateTime = DateTime.Parse(rows[i].FindElement(By.XPath($"//*[@id='b3-b1-MainContent']/div/table/tbody/tr[{i + 1}]/td[2]")).Text);
                    list.Add(data);
                }
                if (!documentsGroupPage.NextPage.Enabled)
                {
                    break;
                }
                documentsGroupPage.NextPage.Click();
                Thread.Sleep(300);
                rows = documentsGroupPage.table.FindElements(By.XPath("//*[@id='b3-b1-MainContent']/div/table/tbody/tr"));

            }


            list = list.OrderBy(p => p.Title).ToList();
            for (int page = numberOfPages - 1; page >= 0; page--)
            {
                for (int i = rows.Count - 1; i >= 0; i--)
                {
                    var title = rows[i].FindElement(By.XPath($"//*[@id='b3-b1-MainContent']/div/table/tbody/tr[{i + 1}]/td[1]")).Text;
                    int idx = Math.Abs(page * (pageEnd - pageStart + 1) - i);
                    Assert.AreEqual(list[idx].Title, title);
                }
                if (!documentsGroupPage.PreviousPage.Enabled)
                {
                    break;
                }
                documentsGroupPage.PreviousPage.Click();
                Thread.Sleep(300);
                rows = documentsGroupPage.table.FindElements(By.XPath("//*[@id='b3-b1-MainContent']/div/table/tbody/tr"));
            }


        }


        [Then(@"I should find Tilte named '([^']*)'")]
        public void ThenIShouldFindTilteNamed(string p0)
        {
            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeSelected(documentsGroupPage.maintitle));
            Assert.AreEqual("The Title is found", documentsGroupPage.maintitle.Text);


        }

        [Then(@"I should find Button named '([^']*)'")]
        public void ThenIShouldFindButtonNamed(string p0)
        {

            documentsGroupPage.Wait.Until(ExpectedConditions.ElementToBeSelected(documentsGroupPage.AddDocumentsGroupButton));
            Assert.AreEqual("The Button is found", documentsGroupPage.AddDocumentsGroupButton.Text);

        }

        [Given(@"I should find Search engine")]
        public void GivenIShouldFindSearchEngine()
        {
            throw new PendingStepException();
        }


        //[Then(@"I should find Clomun(.*) named Title in the tble")]
        //public void ThenIShouldFindClomunNamedTitleInTheTble(int p0)
        //{

        //    if (documentsGroupPage.coloumn1.Displayed)
        //    {
        //        Console.WriteLine("Colomun1 found");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Colomun1 Not found");

        //    }


        //}

        //[Then(@"I should find Clomun(.*) named create time in the tble")]
        //public void ThenIShouldFindClomunNamedCreateTimeInTheTble(int p0)
        //{
        //    if (documentsGroupPage.coloumn2.Displayed) 
        //    {


        //        Console.WriteLine("Colomun2 found");

        //    }
        //    else
        //    {
        //        Console.WriteLine("Colomun2 Not found");

        //    }

        //}
        //[Then(@"I should find Clomun(.*) named action in the tble")]
        //public void ThenIShouldFindClomunNamedActionInTheTble(int p0)
        //{
        //    if (documentsGroupPage.coloumn3.Displayed)
        //    {
        //        Console.WriteLine("Colomun3 found");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Colomun3 Not found");

        //    }


        //}

        //[Then(@"Clomun(.*) is sortable")]
        //public void ThenClomunIsSortable(int p0)
        //{
        //driver.FindElement(By.XPath("//*[@id=\"b3-b1-MainContent\"]/div/table/thead/tr/th[1]/div")).Click();
        //List<WebElement> colname = driver.FindElements(By.CssSelector(".ThemeGrid_MarginGutter:nth-child(3) > span"));

        //String Sorting = new String[colname.Size()];


        //colname.Sort();










    }
}







