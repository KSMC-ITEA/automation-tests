using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace Malafi.Tests.Pages
{
    public class SelfServices
    {
        #region fields
        private WebDriverWait wait; 
        #endregion




        #region Constructor
        public SelfServices(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);


        } 
        #endregion

        public WebDriverWait Wait => wait ?? throw new NullReferenceException();



        #region Properties
        [FindsBy(How = How.Id, Using = "loginButton")]
        public IWebElement Login { get; private set; } 
        #endregion

    }
}