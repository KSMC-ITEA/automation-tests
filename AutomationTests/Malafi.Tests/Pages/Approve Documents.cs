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
    public class Inbox
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Inbox(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }


        public WebDriverWait Wait => wait;


        [FindsBy(How = How.CssSelector, Using = "#\\$b4 > div:nth-child(1) > span")]
        public IWebElement VLD { get; private set; }
        
        [FindsBy(How = How.CssSelector, Using = "#transitionContainer > div > div > div > div > div > div.main-content > div.content-middle.contentMainLeft > div > div > div:nth-child(3) > div > table > tbody > tr:nth-child(1) > td:nth-child(7) > div > div > button.btn.approve-tooltip.ThemeGrid_MarginGutter")]
        public IWebElement ButtonApprove { get; private set; }





        public void ClickButtonApprove()
        {

            Thread.Sleep(900);

            Wait.Until(ExpectedConditions.ElementToBeClickable(ButtonApprove)).Click();
        }

    }
}
