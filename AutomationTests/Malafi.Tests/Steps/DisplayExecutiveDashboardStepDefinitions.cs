using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DisplayExecutiveDashboardStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private Dashboards dashboards;
        private IWebDriver driver;

        public DisplayExecutiveDashboardStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");

        }

        [Then(@"Check Display Dashboard")]
        public void ThenCheckDisplayDashboard()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            malafiHome.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHome.DashboardLink));
            Thread.Sleep(300);

            dashboards = malafiHome.ClickOnExecutiveDashboard();
            Thread.Sleep(300);
            Assert.IsNotNull(dashboards);

            var pending = int.Parse(dashboards.PendingEmployees.Text);
            var approved = int.Parse(dashboards.ApprovedEmployees.Text);
            var rejected = int.Parse(dashboards.RejectedEmployees.Text);
            var allEmployees = int.Parse(dashboards.AlRegisteredEmployees.Text);



            Assert.AreEqual(allEmployees, approved + rejected + pending);






        }

    }
}
