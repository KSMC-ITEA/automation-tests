using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Yaqeen.Tests.Pages;

namespace Yaqeen.Tests.Steps
{
    [Binding]

    public class LoginStepDefinitions
    {
        private LoginPage loginPage;
        private ScenarioContext scenarioContext;
        private string username = string.Empty;
        private string password = string.Empty;
        private ForgotYourPassword forgotYourPassword;

        public LoginStepDefinitions(ScenarioContext context)
        {

            scenarioContext = context;

            loginPage = scenarioContext["LoginPage"] as LoginPage ?? throw new ArgumentNullException("Login Page");

        }


        [Given(@"Entered '([^']*)'as a username")]
        public void GivenEnteredAsAUsername(string userName)
        {
            this.username = userName;

        }

        [Given(@"Enterd '([^']*)' as password")]
        public void GivenEnterdAsPassword(string password)
        {
            this.password  = password;
        }

        [When(@"I cilck on login button")]
        public void WhenICilckOnLoginButton()
        {
            var homePage = loginPage.Login(username, password); 
            scenarioContext["HomePage"] = homePage;
        }

        [Then(@"I should be able to view my home page")]
        public void ThenIShouldBeAbleToViewMyHomePage()
        {
            var homePage = scenarioContext["HomePage"] as HomePage;
            Assert.IsNotNull(homePage);
            Thread.Sleep(1000);
            homePage.Wait.Until(ExpectedConditions.ElementToBeClickable(homePage.FullName));
            Assert.AreEqual("Dev_MOH", homePage.FullName.Text);
        }

        [Then(@"I should be message This field is required")]
        public void ThenIShouldBeMessageThisFieldIsRequired()
        {
            Assert.AreEqual("This field is required", loginPage.PasswordVLD.Text);
            Assert.AreEqual("This field is required", loginPage.UserNameVLD.Text);

        }

        [Then(@"I should be message Sorry, but you don’t have an access permission")]
        public void ThenIShouldBeMessageSorryButYouDonTHaveAnAccessPermission()
        {
            loginPage.Wait.Until(ExpectedConditions.ElementToBeClickable(loginPage.FeedbackMessage));

            Assert.AreEqual("Sorry, but you don’t have an access permission.", loginPage.FeedbackMessage.Text);
        }

        [Then(@"I should be message Login authentication failed, check your username or password\.")]
        public void ThenIShouldBeMessageLoginAuthenticationFailedCheckYourUsernameOrPassword_()
        {
            loginPage.Wait.Until(ExpectedConditions.ElementToBeClickable(loginPage.FeedbackMessage));

            Assert.AreEqual("Login authentication failed, check your username or password.", loginPage.FeedbackMessage.Text);
        }

        [Given(@"Click on Forgot your password link")]
        public void GivenClickOnForgotYourPasswordLink()
        {
            forgotYourPassword = loginPage.ClickOnForgotYourPassword();    

        }

      

        [Then(@"I should be navigated to the moh\.gov\.sa")]
        public void ThenIShouldBeNavigatedToTheMoh_Gov_Sa()
        {
            Thread.Sleep(1000);
            //forgotYourPassword.Wait.Until(ExpectedConditions.UrlContains("https://hsp.moh.gov.sa/resetpassword.aspx"));

            Assert.IsTrue(forgotYourPassword.ForgotYourPasswordUrl.Contains("https://hsp.moh.gov.sa/resetpassword.aspx"));
        }

    }
}
