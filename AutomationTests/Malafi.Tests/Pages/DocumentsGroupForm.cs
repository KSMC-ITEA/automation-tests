using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using Malafi.Tests.Steps;
using System.Reflection;


namespace Malafi.Tests.Pages
{
    public class DocumentsGroupForm
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public DocumentsGroupForm(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }
        public WebDriverWait Wait => wait;

        [FindsBy(How = How.CssSelector, Using = "#b3-b2-Column1 .mandatory > span")]
        public IWebElement LableOfArField { get; private set; }

        
        [FindsBy(How = How.CssSelector, Using = "#b3-Input_TitleAr")]
        public IWebElement ArInputField { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-Input_TitleEn")]
        public IWebElement EnInputField { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement ClickOnSaveButton { get; private set; }


        [FindsBy(How = How.CssSelector, Using = ".feedback-message-text")]
        public IWebElement FeedbackMessage { get; private set; }
        public void AddNewDocumentGroup(DocumentGroupTestData testData)
        {
            ArInputField.SendKeys(testData.TitleAR);
            EnInputField.SendKeys(testData.TitleEN);
            wait.Until(ExpectedConditions.ElementToBeClickable(ClickOnSaveButton)).Click();
        }

    }
}