using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Malafi.Tests.Pages
{
    public class IDApprovallevelList
    {

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public IDApprovallevelList(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }


        public WebDriverWait Wait => wait;


        [FindsBy(How = How.CssSelector, Using = ".btn > .ThemeGrid_MarginGutter")]
        public IWebElement AddApprovalLevelClick { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-b1-Title")]
        public IWebElement IDApprovallevel { get; private set; }






        public NewDocTypeApprovalLVI ClickOnAddApprovallevelLink()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(AddApprovalLevelClick)).Click();

            return new NewDocTypeApprovalLVI(driver);


        }
    }
}
