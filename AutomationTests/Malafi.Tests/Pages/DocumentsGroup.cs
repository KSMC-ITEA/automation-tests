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


        public DocumentsGroupForm ClickOnAddDocumentsGroupLink()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(AddDocumentsGroupButton)).Click();

            return new DocumentsGroupForm(driver);


        }
    }
}

