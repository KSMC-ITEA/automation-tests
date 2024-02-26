using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Malafi.Tests.Pages
{


    public class DocumentType
    {

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;


        public DocumentType(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }


        public WebDriverWait Wait => wait;

        [FindsBy(How = How.XPath, Using = "//div[@id='b3-b1-Actions']/div/button/span")]
        public IWebElement AddDocumentsTypes { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(2) .view-tooltip > .icon")]
        public IWebElement ViewApprovalLevelsIcon { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b1-Title")]
        public IWebElement CheckTitleDocumentsTypes { get; private set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_TextVar']")]
        public IWebElement CheckSearchBox { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='b3-b1-Actions']/div/button/span")]
        public IWebElement CheckAddDocumentTypeButton { get; private set; }


        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(1) .edit-tooltip > .icon")]
        public IWebElement CheckEditButton { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(1) .delete-tooltip > .icon")]
        public IWebElement CheckDeleteButton { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(2) .add-tooltip > .icon")]
        public IWebElement CheckAddButton { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(1) .view-tooltip > .icon")]
        public IWebElement CheckViewButton { get; private set; }

        [FindsBy(How = How.CssSelector, Using = " .sortable-icon")]
        public IWebElement CheckSortaButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Title')]")]
        public IWebElement CheckTitle { get; private set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Is Required')]")]
        public IWebElement CheckIsRequired { get; private set; }

        [FindsBy(How = How.XPath, Using = "//th[contains(.,'Has Expiry')]")]
        public IWebElement CheckHasExpiry { get; private set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Action')]")]
        public IWebElement CheckAction { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b1-MainContent > div > table")]
        public IWebElement TableDocumentTypeList { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b3-PaginationRecords")]
        public IWebElement TableFooter { get; private set; }
        
        [FindsBy(How = How.CssSelector, Using = "//span[contains(.,'Title')]")]
        public IWebElement TitleDocumentTypeList {get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#b3-b3-PaginationContainer > button:nth-child(3)")]
        public IWebElement NextPage { get; private set; }

            [FindsBy(How = How.CssSelector, Using = "#b3-b3-PaginationContainer > button:nth-child(1)")]
        public IWebElement PreviousPage { get; private set; }



        public DocumentsTypeDetails ClickOnAddDocumentsLink()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(AddDocumentsTypes)).Click();

            return new DocumentsTypeDetails(driver);

        }


        
        public IDApprovallevelList ClickOnViewApprovalLevelsIcon()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(ViewApprovalLevelsIcon)).Click();

            return new IDApprovallevelList(driver);

        }


    }

}
