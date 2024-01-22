using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Malafi.Tests.Pages
{

    public class HomePage
    {
        #region Fields
        private readonly IWebDriver driver;
        public WebDriverWait wait;
        private object errorMessage;
        #endregion


        #region Constructor
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }
        #endregion

        // نعرف خاصية نوعها ببليك لان ماينفع نستخدم عناصر الكلاس مباشره 
        public object ErrorMessage =>errorMessage;
        public WebDriverWait Wait => wait ?? throw new NullReferenceException();

        #region Properties
        [FindsBy(How = How.CssSelector, Using = ".main-nav-profile > .ThemeGrid_MarginGutter")]
        public IWebElement FullName { get; private set; }

        [FindsBy(How = How.LinkText, Using = "Malafi")]
        public IWebElement LinkMalafi { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".OSInline:nth-child(2) > div > span")]
        public IWebElement Ar_languages { get; private set; }
        #endregion


        public MalafiHome ClickOnMalafi()
        {
            LinkMalafi.Click();

            return new MalafiHome(driver);
        }


    }
}
    
