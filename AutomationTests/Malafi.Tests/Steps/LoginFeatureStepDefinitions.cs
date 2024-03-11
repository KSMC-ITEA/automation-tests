using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class LoginFeatureStepDefinitions
    {

        #region fields
        private LoginPage loginPage;
        private ScenarioContext scenarioContext;
        private string username = string.Empty;
        private string password = string.Empty;
        private SelfServices  selfServices;
  
        #endregion

        #region Constructor
        public LoginFeatureStepDefinitions(ScenarioContext context)
        {

            scenarioContext = context;

            loginPage = scenarioContext["LoginPage"] as LoginPage ?? throw new ArgumentNullException("Login Page");




        }

        #endregion

        #region Given

        [Given(@"I change the language '([^']*)'")]
        public void GivenIChangeTheLanguage(string language)
        {
            loginPage.ChangeLanguage(language);
        }

        [Given(@"Entered '([^']*)'as a username")]
        public void GivenEnteredAsAUsername(string userName)
        {
            this.username = userName;
        }

        [Given(@"Enterd '([^']*)' as password")]
        public void GivenEnterdAsPassword(string password)
        {
            this.password = password;
        }
        [Given(@"Click on '([^']*)' link")]
        public void GivenClickOnLink(string linkText)
        {

            selfServices = loginPage.ClickOnLinkText(linkText);


        }
        #endregion

        #region When
        [When(@"I cilck on login button")]

        public void WhenICilciOnLoginButton()
        {
            var homePage = loginPage.Login(username, password);
            scenarioContext["HomePage"] = homePage;
        }
        #endregion

        #region Then
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



        [Then(@"I should be navigated to the '([^']*)'")]
        public void ThenIShouldBeNavigatedToThe(string urlPage)
        {
            loginPage.Wait.Until(ExpectedConditions.UrlContains(urlPage));

            // 
            Assert.IsTrue(selfServices.SelfServiceUrl.Contains(urlPage));
        }



     

        [Then(@"The received error message regex should be releted to the selected language '([^']*)'")]
        public void ThenTheRecivedErrorMessageRegexShouldBeReletedToTheSelectedLanguage(string regexPattern)
        {
            loginPage.Wait.Until(ExpectedConditions.ElementToBeClickable(loginPage.Errormessage));
            bool isMatch = Regex.IsMatch(loginPage.Errormessage.Text, regexPattern);
            Assert.AreEqual("اسم المستخدم او كلمة المرور غير صحيحة برجاء ادخال البيانات الصحيحة", loginPage.Errormessage.Text);
        }



        #endregion
    }
}
