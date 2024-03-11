using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Malafi.Tests.Steps;
using SeleniumExtras.WaitHelpers;
using System.Reflection;

namespace Malafi.Tests.Pages
{
    public class MyFiles
    {


        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public MyFiles(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }


        public WebDriverWait Wait => wait;



        [FindsBy(How = How.XPath, Using = "//*[@id=\"$b4\"]/div[1]/span")]
        public IWebElement MyFilesVLD { get; private set; }



        [FindsBy(How = How.CssSelector, Using = "#\\$b4 > div.OSBlockWidget > div > div > div:nth-child(3) > div > div.section-expandable-title > div.section-expandable-icon")]
        public IWebElement FileVLD { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#\\$b4 > div.OSBlockWidget > div > div > div:nth-child(3) > div > div.section-expandable-content.is--expanded > div > table > tbody > tr:nth-child(5) > td:nth-child(6) > div > button")]
        public IWebElement buttonVLD { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "input[type=file]")]
        public IWebElement UploadDocVLD { get; private set; }
        
        [FindsBy(How = How.Id, Using = "b3-TermsAndConditions")]
        public IWebElement VLD { get; private set; }

         [FindsBy(How = How.CssSelector, Using = "#b3-Form1 > div:nth-child(6) > button.btn.btn-primary.ThemeGrid_Width2")]
        public IWebElement SaveVLD { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#\\$b4 > div.OSBlockWidget > div > div > div:nth-child(3) > div > div.section-expandable-content.is--expanded > div > table > thead > tr > th:nth-child(1)")]
        public IWebElement DocTitleVLD { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#\\$b4 > div.OSBlockWidget > div > div > div:nth-child(3) > div > div.section-expandable-content.is--expanded > div > table > thead > tr > th:nth-child(2)")]
        public IWebElement StatusVLD { get; private set; }



        public void MyFilesUpload(MyFilesData testData)
        {
            
            var uploadFile = testData.UploadFile;
            this.UploadDocVLD.SendKeys($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\FilesToUpload\\{uploadFile}");

            wait.Until(ExpectedConditions.ElementToBeClickable(VLD)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(SaveVLD)).Click();

        }

    }
}
