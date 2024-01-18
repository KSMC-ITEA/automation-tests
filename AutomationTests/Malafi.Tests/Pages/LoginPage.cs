using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Malafi.Tests.Pages
{

    //هذه الصفحة تمثل كلاس لصفحة اللوقين راح نرجع نستخدمة 
    public class LoginPage
    {

        #region Fields
        private IWebDriver driver;
        private WebDriverWait Wait;
        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "b2-UsernameInput")]
        public IWebElement UserName { get; private set; }

        #endregion

        #region Properties
        [FindsBy(How = How.Id, Using = "b2-PasswordInput")]
        public IWebElement PasswordTextBox { get; private set; }
        [FindsBy(How = How.Id, Using = "b2-PasswordInput")]
        public IWebElement PasswordValue { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement LoginButton { get; private set; }
        #endregion
     

        public HomePage Login(string userName, string password )
        { 
            this.Wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginButton));
            this.UserName.SendKeys(userName);
            this .PasswordTextBox.SendKeys(password);
            this.LoginButton.Click();
            
            return new HomePage(driver);
        }

       

       
    }
}