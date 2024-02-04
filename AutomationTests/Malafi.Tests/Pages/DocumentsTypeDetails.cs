using Malafi.Tests.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Reflection;

namespace Malafi.Tests.Pages
{
    public class DocumentsTypeDetails
    {
        private readonly IWebDriver driver;

        public readonly WebDriverWait wait;
        public DocumentsTypeDetails(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;


        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_TitleAr']")]
        public IWebElement TitleAr { get; private set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_TitleEn']")]
        public IWebElement TitleEn { get; private set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_WebsiteLink']")]
        public IWebElement WebsiteLink { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "btn-primary")]
        public IWebElement UploadDocumentType { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#b3-Input_OnBaseNumber")]
        public IWebElement OnBaseNumber { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "input[type=file]")]
        public IWebElement FileUpload { get; private set; }

        [FindsBy(How = How.XPath,Using = "//form[@id='b3-Form1']/div[2]/button[2]/span")]
        public IWebElement ClickOnSaveButton1 { get; private set; }

        [FindsBy(How = How.ClassName, Using = "feedback-message-text")]
        public IWebElement FeedbackMessage { get; private set; }



        public void AddNewDocumentType(TestData testData)
        {
            TitleAr.SendKeys(testData.TitleAR);
            TitleEn.SendKeys(testData.TitleEN);
            WebsiteLink.SendKeys(testData.WebsiteLink);
            var uploadFile = testData.UploadFile;
            this.FileUpload.SendKeys($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\FilesToUpload\\{uploadFile}");
            OnBaseNumber.SendKeys(testData.OnBaseNumber);
            wait.Until(ExpectedConditions.ElementToBeClickable(ClickOnSaveButton1)).Click();
        }
        
    }

}
