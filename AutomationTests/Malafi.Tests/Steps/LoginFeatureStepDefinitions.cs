using Malafi.Tests.Pages;

using SeleniumExtras.WaitHelpers;

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
        #endregion

        #region Constructor
        public LoginFeatureStepDefinitions(ScenarioContext context)
        {

            scenarioContext = context;

            loginPage = scenarioContext["LoginPage"] as LoginPage ?? throw new ArgumentNullException("Login Page");

        }

        #endregion


        #region Given
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


        [Given(@"click selfservices putton\.")]
        public void GivenClickSelfservicesPutton_()
        {
            var selfServices = loginPage.Click();
            scenarioContext["SelfServices"] = selfServices;

        }


        [Given(@"click forget password putton\.")]
        public void GivenClickForgetPasswordPutton_()
        {
            var selfServices = loginPage.Open();
            scenarioContext["SelfServices"] = selfServices;


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






        [Then(@"I should move to selfservices page\.")]
        public void ThenIShouldMoveToSelfservicesPage_()
        {
            var selfServices = scenarioContext["SelfServices"] as SelfServices;
            Assert.IsNotNull(selfServices);
            selfServices.Wait.Until(ExpectedConditions.ElementToBeClickable(selfServices.Login)); ;

            Assert.AreEqual("Login", selfServices.Login.GetDomAttribute("value"));

        } 
        #endregion




    }
}
