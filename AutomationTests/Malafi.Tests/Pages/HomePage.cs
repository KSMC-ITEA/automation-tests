using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Malafi.Tests.Pages
{

    public class HomePage
    {

        #region Fields
        private WebDriverWait wait;
        #endregion


        #region Constructor
        public HomePage(IWebDriver driver)
        {


            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }
        #endregion


        #region Exception Handling 
        public WebDriverWait Wait => wait ?? throw new NullReferenceException(); 
        #endregion

        #region Properties
        [FindsBy(How = How.CssSelector, Using = ".main-nav-profile > .ThemeGrid_MarginGutter")]
        public IWebElement FullName { get; private set; } 
        #endregion

    }
}
    
