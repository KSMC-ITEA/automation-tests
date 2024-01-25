using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
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


        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_TitleAr']")]
        public IWebElement Title_Ar { get; private set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_TitleEn']")]
        public IWebElement Title_En { get; private set; }


        [FindsBy(How = How.XPath, Using = "//input[@id='b3-Input_WebsiteLink']")]
        public IWebElement Website_Link { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "btn-primary")]
        public IWebElement Upload_Document_Type { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "#b3-Input_OnBaseNumber")]
        public IWebElement OnBase_Number { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "input[type=file]")]
        public IWebElement FileUpload { get; private set; }



        public void New_Document_Type(string Title_Ar1, string Title_En1, string Website_Link1, string OnBase_Number1, string uploadFile1)
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(Title_Ar));

            Title_Ar.SendKeys(Title_Ar1);


            wait.Until(ExpectedConditions.ElementToBeClickable(Title_En));

            Title_En.SendKeys(Title_En1);


            wait.Until(ExpectedConditions.ElementToBeClickable(Website_Link));

            Website_Link.SendKeys(Website_Link1);

            //Upload_Document_Type.Click();

            var uploadFile = uploadFile1;
            this.FileUpload.SendKeys(uploadFile);
            //driver.FindElement(By.Id("file-submit")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(OnBase_Number));

            OnBase_Number.SendKeys(OnBase_Number1);



        }
    }

}