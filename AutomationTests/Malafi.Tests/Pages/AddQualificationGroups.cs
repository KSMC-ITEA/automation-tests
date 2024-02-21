using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Pages
{
    public class AddQualificationGroups
    {

        #region Fields
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        int numberOfRows;
        #endregion


        #region Constructor
        public AddQualificationGroups(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }
        #endregion
        public WebDriverWait Wait => wait;

       [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(1) .add-tooltip > .icon")]
       public IWebElement AddingDocumentGroupButton { get; private set; }

        [FindsBy(How =How.XPath, Using = "//*[@id='b3-b7-MainContent']/div/table")]
        public IWebElement DocumentsGroupTable {  get; private set; }
        [FindsBy(How =How.XPath,Using = "//*[@id='b3-b9-MainContent']/div/table")]
        public IWebElement AssignedDocumentGroups { get; private set; }

        [FindsBy(How = How.XPath,Using = "//*[@id='b3-b10-PaginationRecords']")]
        public IWebElement TableFooter { get; private set; }
        [FindsBy(How = How.XPath,Using = "//*[@id='b3-b10-PaginationContainer']/button[2]")]
        public IWebElement NextPage { get; private set; }



    
    /*    public  int giveNumberOfRows()
        {

         var numberOfRows = DocumentsGroupTable.FindElements(By.XPath("//tbody/tr")).Count;
         return  numberOfRows;

        }*/
    

    }
}

