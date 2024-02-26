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


        [FindsBy(How = How.CssSelector, Using = "#b3-b1-b2-Content > div:nth-child(1) > span.font-size-display")]
        public IWebElement AlRegisteredEmployees { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b2-Column1 > div > table > tbody > tr:nth-child(1) > td:nth-child(2) > span")]
        public IWebElement ApprovedEmployees { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b2-Column1 > div > table > tbody > tr:nth-child(2) > td:nth-child(2) > span")]
        public IWebElement PendingEmployees { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b2-Column1 > div > table > tbody > tr:nth-child(3) > td:nth-child(2) > span")]
        public IWebElement RejectedEmployees { get; private set; }


    }
}
