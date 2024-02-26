using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace Malafi.Tests.Pages
{
    public class DocumentsGroup
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public DocumentsGroup(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }



        public WebDriverWait Wait => wait;

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement AddDocumentsGroupButton { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".active > span")]
        public IWebElement maintitle { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-Input_TextVar")]
        public IWebElement SearchEngine { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".btn > .ThemeGrid_MarginGutter")]
        public IWebElement AddDocumentGroup { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b1-MainContent']/div/table")]
        public IWebElement table { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"b3-b1-MainContent\"]/div/table/thead/tr")]
        public IWebElement header { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b1-MainContent']/div/table/thead/tr/th[1]")]
        public IWebElement Column1 { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b3-PaginationRecords']")]
        public IWebElement TableFooter { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b3-PaginationContainer']/button[2]")]
        public IWebElement NextPage { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b3-PaginationContainer']/button[1]")]
        public IWebElement PreviousPage { get; private set; }

        //[FindsBy(How=How.CssSelector,Using = "th:nth-child(1)")]
        //public IWebElement coloumn1 { get; private set; }

        //[FindsBy(How = How.CssSelector, Using = ".sortable:nth-child(1)")]
        //public IWebElement coloumn1_1 { get; private set; }


        //[FindsBy(How = How.CssSelector, Using = "th:nth-child(2)")]
        //public IWebElement coloumn2 { get; private set; }

        //[FindsBy(How = How.CssSelector, Using = ".sortable:nth-child(2)")]
        //public IWebElement coloumn2_2 { get; private set; }



        //[FindsBy(How = How.CssSelector, Using = "th:nth-child(3)")]
        //public IWebElement coloumn3 { get; private set; }

        //[FindsBy(How=How.CssSelector,Using = ".ThemeGrid_MarginGutter:nth-child(3) > span")]
        //public IWebElement Grid { get; private set; }


        public DocumentsGroupForm ClickOnAddDocumentsGroupLink()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(AddDocumentsGroupButton)).Click();

            return new DocumentsGroupForm(driver);


        }
    }
}

