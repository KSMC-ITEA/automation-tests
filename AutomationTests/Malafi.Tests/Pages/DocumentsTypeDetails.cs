using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Malafi.Tests.Pages
{
    public class DocumentsTypeDetails
    {
        private readonly IWebDriver driver;

        public WebDriverWait wait;
        public DocumentsTypeDetails(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;


        [FindsBy(How = How.Id, Using = "b3-Input_TitleAr")]
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
        public IWebElement SuccessMessage { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='feedbackMessageContainer']/div/div")]
        public IWebElement ErrorMessage { get; private set; }


        public void New_Document_Type(string TitleAr1, string TitleEn1, string WebsiteLink1, string OnBaseNumber1, string UploadFile1)
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(TitleAr));

            TitleAr.SendKeys(TitleAr1);


            wait.Until(ExpectedConditions.ElementToBeClickable(TitleEn));

            TitleEn.SendKeys(TitleEn1);


            wait.Until(ExpectedConditions.ElementToBeClickable(WebsiteLink));

            WebsiteLink.SendKeys(WebsiteLink1);

            //Upload_Document_Type.Click();

            var uploadFile = UploadFile1;
            this.FileUpload.SendKeys($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\FilesToUpload\\{UploadFile1}");
            //driver.FindElement(By.Id("file-submit")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(OnBaseNumber));

            OnBaseNumber.SendKeys(OnBaseNumber1);



        }
    
        //ضغط على زر الحفظ
        
        public void ClickOnSaveButton()
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(ClickOnSaveButton1)).Click();

        }
    }

}
//Data has been updated successfully

//feedback-message-text