using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace Malafi.Tests.Pages
{


    public class LoginPage
    {

        #region Fields
        private IWebDriver driver;
        private WebDriverWait wait;
        private Dictionary<string, IWebElement> loginPageLinks;

        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
            LoginPageLinks = new Dictionary<string, IWebElement>();
            /// key of the dictionay key,valu 
            LoginPageLinks.Add("Forgot your password?", ForgetMyCredentialLinks);
            LoginPageLinks.Add("Self Services", SlefServicesLinks);
            //language = new Dictionary<string, IWebElement>();


        }

        #endregion

        #region Properties
        public WebDriverWait Wait => wait;
        [FindsBy(How = How.Id, Using = "b1-LanguageButton")]
        public IWebElement Language { get; private set; }

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
        [FindsBy(How = How.LinkText, Using = "Forgot your password?")]
        public IWebElement ForgetMyCredentialLinks { get; private set; }



        [FindsBy(How = How.LinkText, Using = "Self Services")]
        public IWebElement SlefServicesLinks { get; private set; }
        public Dictionary<string, IWebElement> LoginPageLinks { get => loginPageLinks; private set => loginPageLinks = value; }
        #endregion




        #region Methods - Page Navigation

        /// <summary>
        /// Login with valid userName and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public HomePage Login(string userName, string password)
        {


            this.UserName.SendKeys(userName);
            this.PasswordTextBox.SendKeys(password);
            this.wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginButton));
            Thread.Sleep(5000);
            this.LoginButton.Click();


            return new HomePage(driver);
        }
        
        /// <summary>
        /// When click on link text
        /// </summary>
        /// <param name="LinkText"></param>
        public void ClickOnLinkText(string LinkText)
        {
            this.LoginPageLinks[LinkText].Click();
        }
        

        public void ChangeLanguage(string language = "en")
        {
            while (true)
            {
                if (language == "en" && Language.Text == "عربي")
                    break;

                if (language == "ar" && Language.Text == "English")
                    break;

                Language.Click();
            }
        }




        #endregion




    }
}