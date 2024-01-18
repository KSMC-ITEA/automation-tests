using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Malafi.Tests.Pages
{

    public class HomePage
    {
        private IWebDriver driver;
        public WebDriverWait wait;
        internal object ErrorMessage;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }

       

        [FindsBy(How = How.CssSelector, Using = ".main-nav-profile > .ThemeGrid_MarginGutter")]
        public IWebElement FullName { get; private set; }

    }
}
    
