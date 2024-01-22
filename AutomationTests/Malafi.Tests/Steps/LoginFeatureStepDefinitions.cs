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
        private string username = string.Empty;
        private string password = string.Empty;

        public LoginFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new ArgumentNullException("Web Driver");
            loginPage = scenarioContext["LoginPage"] as LoginPage ?? throw new ArgumentNullException("Login Page");

        }



        [Given(@"Entered '([^']*)'as a username")]
        public void GivenEnteredAsAUsername(string userName)
        {
            //loginPage = new LoginPage(driver);
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
            var homePage = loginPage.Login(username, password);
            scenarioContext["HomePage"] = homePage;

        }

        [Then(@"I should be able to view my home page")]
        public void ThenIShouldBeAbleToViewMyHomePage()
        {

            var homePage = scenarioContext["HomePage"] as HomePage;
            Assert.IsNotNull(homePage);
            homePage.Wait.Until(ExpectedConditions.ElementToBeClickable(homePage.FullName));//By.Id(homePage.FullName.GetAttribute("id"))));

            Assert.AreEqual("Blue2", homePage.FullName.Text);





        }

        [Then(@"I should not be able to view my home page")]
        public void ThenIShouldNotBeAbleToViewMyHomePage()
        {
            loginPage.Wait.Until(ExpectedConditions.ElementToBeClickable(loginPage.Errormessage));
            Assert.AreEqual("اسم المستخدم او كلمة المرور غير صحيحة برجاء ادخال البيانات الصحيحة", loginPage.Errormessage.Text);
        }



        [Given(@"click forget password putton\.")]
        public void GivenClickForgetPasswordPutton_()
        {
            var selfServices = loginPage.Open();
            scenarioContext["SelfServices"] = selfServices;


        }

        [Then(@"I should move to selfservices page\.")]
        public void ThenIShouldMoveToSelfservicesPage_()
        {
            var selfServices = scenarioContext["SelfServices"] as SelfServices;
            Assert.IsNotNull(selfServices);
            selfServices.Wait.Until(ExpectedConditions.ElementToBeClickable(selfServices.Login)); ;

            Assert.AreEqual("Login", selfServices.Login.GetDomAttribute("value"));

        }


    }
}
