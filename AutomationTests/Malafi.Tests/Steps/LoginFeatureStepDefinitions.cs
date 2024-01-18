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
        private ScenarioContext ScenarioContext;

        public LoginFeatureStepDefinitions(ScenarioContext context)
        {
            ScenarioContext = context;
            driver = ScenarioContext["WebDriver"] as IWebDriver;

        }

        [Given(@"I have naveigated to the research login page")]
        public void GivenIHaveNaveigatedToTheResearchLoginPage()
        {
            //driver.Navigate().GoToUrl("https://osqa.ksmc.med.sa/IPortal/Login");
            //driver.Manage().Window.Maximize();
        }

        [Given(@"Entered '([^']*)'as a username")]
        public void GivenEnteredAsAUsername(string userName)
        {
            loginPage = new LoginPage(driver);
            loginPage.UserName.SendKeys(userName);

        }

        [Given(@"Enterd '([^']*)' as password")]
        public void GivenEnterdAsPassword(string password)
        {
            loginPage.PasswordValue.SendKeys(password);
        }

        [When(@"I cilci on login button")]
        public void WhenICilciOnLoginButton()
        {
            var homePage = loginPage.Login();
            ScenarioContext["HomePage"] = homePage;

        }

        [Then(@"I should be able to view my home page")]
        public void ThenIShouldBeAbleToViewMyHomePage()
        {

            var homePage = ScenarioContext["HomePage"] as HomePage;
            homePage.wait.Until(ExpectedConditions.ElementToBeClickable(homePage.FullName));//By.Id(homePage.FullName.GetAttribute("id"))));

            Assert.AreEqual("Blue2", homePage.FullName.Text);
        }
    }
}
