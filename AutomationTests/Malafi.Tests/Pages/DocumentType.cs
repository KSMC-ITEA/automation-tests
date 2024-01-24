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
        private WebDriverWait wait;

        public DocumentType(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            PageFactory.InitElements(driver, this);
        }


        public WebDriverWait Wait => wait;
        
        [FindsBy(How = How.CssSelector, Using = ".btn > .ThemeGrid_MarginGutter")]
        public IWebElement AddDocumentsTypes { get; private set; }

        public DocumentsTypeDetails AddDocuments()
        {
            var DocumentsTypeDetails = new DocumentsTypeDetails(driver);

            Wait.Until(ExpectedConditions.ElementToBeClickable(AddDocumentsTypes)).Click();

            return new DocumentsTypeDetails(driver);


        }


    }
}
