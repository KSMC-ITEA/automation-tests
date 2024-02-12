using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class HomePageFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        private MalafiHome malafiHome;
        public HomePageFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");

        }
        [When(@"Click on Malafi link")]
        public void WhenClickOnMalafiLink()
        {
            var homePage = scenarioContext["HomePage"] as HomePage;
            Assert.IsNotNull(homePage);
            homePage.Wait.Until(ExpectedConditions.ElementToBeClickable(homePage.MalafiLink));
            var malafiHome = homePage.ClickOnMalafi();
            scenarioContext["MalafiHome"] = malafiHome;
            malafiHome.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHome.DocumentTypeLink));
        }

        [Then(@"I should be navigated to Malafi Home Page")]
        public void ThenIShouldBeNavigatedToMalafiHomePage()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            Assert.AreEqual("Documents Types", malafiHome.DocumentTypeLink.Text);
        }

       


    }
}
