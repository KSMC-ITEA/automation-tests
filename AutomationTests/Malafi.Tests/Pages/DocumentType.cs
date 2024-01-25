using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public DocumentsTypeDetails ClickOnAddDocumentsLink()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(AddDocumentsTypes)).Click();

            return new DocumentsTypeDetails(driver);


        }


    }
}
