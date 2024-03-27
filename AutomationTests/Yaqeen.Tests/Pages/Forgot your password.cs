using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Yaqeen.Tests.Pages
{
    public class ForgotYourPassword
    {
        private readonly IWebDriver driver;

        #region fields
        private WebDriverWait wait;

        #endregion




        #region Constructor
        public ForgotYourPassword(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            //ForgotYourPasswordUrl = driver.Url;
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            this.driver = driver;
        }
        #endregion

        public WebDriverWait Wait => wait ?? throw new NullReferenceException();


        public string ForgotYourPasswordUrl => driver.Url;



    }
}
