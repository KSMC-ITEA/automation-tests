using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yaqeen.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private WebDriverWait wait;
        private Dictionary<string, IWebElement> loginPageLinks;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }
        public WebDriverWait Wait => wait;

        [FindsBy(How = How.Id, Using = "b3-Input_TextVar")]
        public IWebElement UserName { get; private set; }
        
        [FindsBy(How = How.Id, Using = "b3-Input_TextVar2")]
        public IWebElement PasswordTextBox { get; private set; }
        
        [FindsBy(How = How.Id, Using = "b3-TextBox2")]
        public IWebElement PasswordValue { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-Button")]
        public IWebElement LoginButton { get; private set; }
        
        [FindsBy(How = How.CssSelector, Using = "#b3-Input_TextVar_DescribedBy")]
        public IWebElement UserNameVLD { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-Input_TextVar2_DescribedBy")]
        public IWebElement PasswordVLD { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".feedback-message")]
        public IWebElement FeedbackMessage { get; private set; }


        [FindsBy(How = How.LinkText, Using = "Forgot your password?")]
        public IWebElement ForgotYourPassword { get; private set; }
        public Dictionary<string, IWebElement> LoginPageLinks { get => loginPageLinks; private set => loginPageLinks = value; }



        public HomePage Login(string userName, string password)
        {

            this.UserName.SendKeys(userName);
            this.PasswordTextBox.Click();
            this.PasswordTextBox.SendKeys(password);
            this.LoginButton.Click();
            return new HomePage(driver);
        }



        public ForgotYourPassword ClickOnForgotYourPassword()
        {
            Thread.Sleep(900);

            Wait.Until(ExpectedConditions.ElementToBeClickable(ForgotYourPassword)).Click();
            Thread.Sleep(300);

            return new ForgotYourPassword(driver);
        }




    }
}
