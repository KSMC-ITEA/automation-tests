using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malafi.Tests.Pages
{
    public class Dashboards
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Dashboards(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;


        [FindsBy(How = How.CssSelector, Using = ".content-middle > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > span:nth-child(1)")]
        public IWebElement AlRegisteredEmployees { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "div.margin10px:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > table:nth-child(2) > tbody:nth-child(2) > tr:nth-child(1) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement ApprovedEmployees { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "div.margin10px:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > table:nth-child(2) > tbody:nth-child(2) > tr:nth-child(2) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement PendingEmployees { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "div.margin10px:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > table:nth-child(2) > tbody:nth-child(2) > tr:nth-child(3) > td:nth-child(2) > span:nth-child(1)")]
        public IWebElement RejectedEmployees { get; private set; }


    }
}
