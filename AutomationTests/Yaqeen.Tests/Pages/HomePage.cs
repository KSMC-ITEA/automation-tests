using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaqeen.Tests.Pages
{
    public class HomePage
    {

        private readonly IWebDriver driver;
        private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }

        public WebDriverWait Wait => wait;

        [FindsBy(How = How.CssSelector, Using = "#b1-LayoutWrapper > div > header > div > div > div.header-navigation.OSInline > div > nav > div.app-login-info.ph.ThemeGrid_Width2.ThemeGrid_MarginGutter > div > div > div > div:nth-child(1) > div > span")]
        public IWebElement FullName { get; private set; }



    }
}
