


using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DocumentTypeFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private DocumentType documentTypesPage;
        private IDApprovallevelList iDApprovallevelList;

        public DocumentTypeFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            documentTypesPage = scenarioContext["DocumentTypesPage"] as DocumentType ?? throw new NullReferenceException("Document Type Page is NULL.");
        }

        [When(@"I click on Add Document Type button")]
        public void WhenIClickOnAddDocumentTypeButton()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));

            scenarioContext["DocumentTypeDetails"] = documentTypesPage.ClickOnAddDocumentsLink();

        }


        [When(@"Click on Add Document Type button")]
        public void WhenClickOnAddDocumentTypeButton()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            documentTypesPage = malafiHome.ClickOnDocumentTypeLink();
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.AddDocumentsTypes));

            scenarioContext["DocumentTypeDetails"] = documentTypesPage.ClickOnAddDocumentsLink();
        }







        [Then(@"I should be navigated to Add Document Types Page")]
        public void ThenIShouldBeNavigatedToAddDocumentTypesPage()
        {
            var addDocumentTypePage = scenarioContext["DocumentTypeDetails"] as DocumentsTypeDetails;
            Assert.IsNotNull(addDocumentTypePage);
            addDocumentTypePage.Wait.Until(ExpectedConditions.ElementToBeClickable(addDocumentTypePage.ClickOnSaveButton1));
            Assert.IsTrue(addDocumentTypePage.ClickOnSaveButton1.Displayed);
        }



        [When(@"I click on View approval levels button")]
        public void WhenIClickOnViewApprovalLevelsButton()
        {
            iDApprovallevelList = documentTypesPage.ClickOnViewApprovalLevelsIcon();
            scenarioContext["IDApprovallevelList"] = iDApprovallevelList;


        }

        [Then(@"I should be navigated toIDApproval level List Page")]
        public void ThenIShouldBeNavigatedToIDApprovalLevelListPage()
        {
            var IDApprovallevelList = scenarioContext["IDApprovallevelList"] as IDApprovallevelList;
            Thread.Sleep(100);
            Assert.IsNotNull(IDApprovallevelList);
            IDApprovallevelList.Wait.Until(ExpectedConditions.ElementToBeClickable(IDApprovallevelList.AddApprovalLevelClick));

            Assert.AreEqual("Add Approval level", IDApprovallevelList.AddApprovalLevelClick.Text);


        }

        [When(@"I click on AddApprovalLevelClick button")]
        public void WhenIClickOnAddApprovalLevelClickButton()
        {
            Thread.Sleep(100);
            var NewDocTypeApprovalLVI = iDApprovallevelList.ClickOnAddApprovallevelLink();
            scenarioContext["NewDocTypeApprovalLVI"] = NewDocTypeApprovalLVI;

        }

        [Then(@"I should see Title in the top left corner")]
        public void ThenIShouldSeeTitleInTheTopLeftCorner_()
        {
            Assert.AreEqual("Document Type List", documentTypesPage.CheckTitleDocumentsTypes.Text);

        }

        [Then(@"I should see search box and add document type button in the top right corner")]
        public void ThenIShouldSeeSearchBoxAndAddDocumentTypeButtonInTheTopRightCorner_()
        {
            Assert.IsTrue(documentTypesPage.CheckSearchBox.Enabled);
            Assert.IsTrue(documentTypesPage.CheckAddDocumentTypeButton.Enabled);
            Assert.AreEqual("Add Document Type", documentTypesPage.CheckAddDocumentTypeButton.Text);

        }

        [Then(@"I should see for buttons Edit Delete Add it to Documents Group View approval levels")]
        public void ThenIShouldSeeForButtonsEditDeleteAddItToDocumentsGroupViewApprovalLevels_()
        {
            Assert.IsTrue(documentTypesPage.CheckEditButton.Enabled);
            Assert.IsTrue(documentTypesPage.CheckDeleteButton.Enabled);
            Assert.IsTrue(documentTypesPage.CheckAddDocumentTypeButton.Enabled);
            Assert.IsTrue(documentTypesPage.CheckViewButton.Enabled);


        }

        [Given(@"Click on sortable-icon")]
        public void GivenClickOnSortable_Icon()
        {
            documentTypesPage.Wait.Until(ExpectedConditions.ElementToBeClickable(documentTypesPage.CheckSortaButton)).Click();  
        }

        [Then(@"I should see in table sortable-icon")]
        public void ThenIShouldSeeInTableSortable_Icon()
        {
            Assert.IsTrue(documentTypesPage.CheckSortaButton.Enabled);

        }

        [Then(@"I should see table Title and Is Required and Has Expiry and Action and sortable-icon it works")]
        public void ThenIShouldSeeTableTitleAndIsRequiredAndHasExpiryAndActionAndSortable_IconItWorks()
        {
            Assert.AreEqual("Title", documentTypesPage.CheckTitle.Text);

            Assert.AreEqual("Is Required", documentTypesPage.CheckIsRequired.Text);

            Assert.AreEqual("Has Expiry", documentTypesPage.CheckHasExpiry.Text);

            Assert.AreEqual("Action", documentTypesPage.CheckAction.Text);



          
            var rows = documentTypesPage.TableDocumentTypeList.FindElements(By.XPath("//*[@id=\"b3-b1-MainContent\"]/div/table/tbody/tr[1]"));
            List<DocumentTypeItem> list = new List<DocumentTypeItem>();
            string footerText = documentTypesPage.TableFooter.Text;
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
                    DocumentTypeItem data = new DocumentTypeItem();
 
                    data.Title = rows[i].FindElement(By.XPath($"//*[@id=\"b3-b1-MainContent\"]/div/table/tbody/tr[{i + 1}]/td[1]")).Text;
                    list.Add(data);
                }
                if (!documentTypesPage.NextPage.Enabled)
                {
                    break;
                }
                documentTypesPage.NextPage.Click();
                Thread.Sleep(300);
                rows = documentTypesPage.TableDocumentTypeList.FindElements(By.XPath("//*[@id='b3-b1-MainContent']/div/table/tbody/tr"));
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
                if (!documentTypesPage.PreviousPage.Enabled)
                {
                    break;
                }
                documentTypesPage.PreviousPage.Click();
                Thread.Sleep(300);
                rows = documentTypesPage.TableDocumentTypeList.FindElements(By.XPath("//*[@id='b3-b1-MainContent']/div/table/tbody/tr"));
            }




        }

    }

}






