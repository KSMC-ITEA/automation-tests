using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class LoginFeatureStepDefinitions
    {
        private IWebDriver driver;//= new ChromeDriver();
        private LoginPage loginPage;
        private ScenarioContext scenarioContext;
        private string username;
        private string password;
        public LoginFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver;

        }

      

        [Given(@"Entered '([^']*)'as a username")]
        public void GivenEnteredAsAUsername(string userName)
        {
            loginPage = new LoginPage(driver);
          ////  loginPage.UserName.SendKeys(userName);
          
this.username = userName;
        }

        [Given(@"Enterd '([^']*)' as password")]
        public void GivenEnterdAsPassword(string password)
        {
         //   loginPage.PasswordValue.SendKeys(password);

            this.password = password;
        }

        [When(@"I cilck on login button")]
        public void WhenICilciOnLoginButton()
        {
            var homePage = loginPage.Login(username,password);
            scenarioContext["HomePage"] = homePage;

        }

        [Then(@"I should be able to view my home page")]
        public void ThenIShouldBeAbleToViewMyHomePage()
        {

            var homePage = scenarioContext["HomePage"] as HomePage;
            homePage.Wait.Until(ExpectedConditions.ElementToBeClickable(homePage.FullName));//By.Id(homePage.FullName.GetAttribute("id"))));

            Assert.AreEqual("Blue2", homePage.FullName.Text);
        }
    }
}
