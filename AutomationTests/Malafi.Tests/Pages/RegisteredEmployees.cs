using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Malafi.Tests.Pages
{
    public class RegisteredEmployees
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public RegisteredEmployees(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;


        [FindsBy(How = How.XPath, Using = "//div[@id='b3-b1-MainContent']/div/table/tbody/tr/td[4]/div/div[3]/button/img")]
        public IWebElement EmployeeName { get; private set; }


        [FindsBy(How = How.CssSelector, Using = ".btn:nth-child(2)")]
        public IWebElement SaveChanges { get; private set; }


        [FindsBy(How = How.CssSelector, Using = ".swal2-confirm")]
        public IWebElement SaveChangesPopup { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-RadioButton2")]
        public IWebElement Approved { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(1) .edit-tooltip .icon")]
        public IWebElement ViewDoc { get; private set; }
        [FindsBy(How = How.CssSelector, Using = "#b1-MainContent > div:nth-child(1) > div > div > div.OSBlockWidget > div > div > div:nth-child(3)")]
        public IWebElement TitleWrapper { get; private set; }
        
        [FindsBy(How = How.CssSelector, Using = "#b1-MainContent > div:nth-child(1) > div > div > div.OSBlockWidget > div > div > div:nth-child(3) > div > div.section-expandable-content.is--expanded > div > table > tbody > tr:nth-child(1) > td:nth-child(6) > div > button > img")]
        public IWebElement ViewDoc2 { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".ThemeGrid_Width4:nth-child(2)")]
        public IWebElement ViewApprovalTimline { get; private set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'1079039804')]")]
        public IWebElement NumberEmployeeIdVLD { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#transitionContainer > div > div > div > div > div > div.main-content > div.content-middle.contentMainLeft > div > div > div > div.list.list-group.OSFillParent > div:nth-child(2) > div > div.timeline-content > div:nth-child(1) > div > span.ThemeGrid_MarginGutter")]
        public IWebElement NameEmployeeIdVLD { get; private set; }
        
        [FindsBy(How = How.CssSelector, Using = "#transitionContainer > div > div > div > div > div > div.main-content > div.content-middle.contentMainLeft > div > div > div > div.list.list-group.OSFillParent > div:nth-child(2) > div > div.ph.timeline-left.OSInline > div > div:nth-child(2) > div:nth-child(2) > span")]
        public IWebElement DataExpressiondVLD { get; private set; }


        [FindsBy(How = How.LinkText, Using = "Download previously uploaded File")]
        public IWebElement DownloadPreviouslyUploadedFile { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b1-MainContent > div:nth-child(1) > div > div > div.OSBlockWidget > div > div > div:nth-child(2) > div > div.section-expandable-title > div.section-expandable-icon")]
        public IWebElement TitleWrapperDisplay  { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#b1-MainContent > div:nth-child(1) > div > div > div.OSBlockWidget > div > div > div:nth-child(2) > div > div.section-expandable-content.is--expanded > div > table > tbody > tr:nth-child(1) > td:nth-child(6) > div > button > img")]
        public IWebElement ViewDocDisplay { get; private set; }



        public void FormRegisteredEmployeesValidation()
        {


            wait.Until(ExpectedConditions.ElementToBeClickable(SaveChanges)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(SaveChangesPopup)).Click();

        }
    }
}
