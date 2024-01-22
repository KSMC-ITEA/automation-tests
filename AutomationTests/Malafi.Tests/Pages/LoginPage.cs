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
        private WebDriverWait wait;
        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(wd => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").ToString() == "complete");
            PageFactory.InitElements(driver, this);
        }

        #endregion

        #region Properties
        public WebDriverWait Wait => wait;


        [FindsBy(How = How.Id, Using = "b2-UsernameInput")]
        public IWebElement UserName { get; private set; }

        [FindsBy(How = How.Id, Using = "b2-PasswordInput")]
        public IWebElement PasswordTextBox { get; private set; }
        [FindsBy(How = How.Id, Using = "b2-PasswordInput")]
        public IWebElement PasswordValue { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement LoginButton { get; private set; }

        [FindsBy(How = How.ClassName, Using = "feedback-message-error")]
        public IWebElement Errormessage { get; private set; }

        [FindsBy(How = How.ClassName, Using = "password-link")]
        public IWebElement ForgetMyCredential { get; private set; }
        #endregion




        #region Methods - Page Navigation
        public HomePage Login(string userName, string password)
        {
            this.UserName.SendKeys(userName);
            this.PasswordTextBox.SendKeys(password);
            this.wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginButton));
            Thread.Sleep(5000);
            this.LoginButton.Click();

            return new HomePage(driver);
        } 
        public SelfServices Open()
        {
            this.wait.Until(ExpectedConditions.ElementToBeClickable(this.ForgetMyCredential));
            this.ForgetMyCredential.Click();
            return new SelfServices(driver);


        }
        #endregion




    }
}