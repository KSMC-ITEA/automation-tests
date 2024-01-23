using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow.Tracing;

namespace Malafi.Tests.Hooks
{
    [Binding]
    public sealed class MalafiHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public MalafiHooks(FeatureContext fContext, ScenarioContext context)
        {
            scenarioContext = context;
            featureContext = fContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver; //= new ChromeDriver();
            switch (Properties.Resources.Browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Navigate().GoToUrl(Properties.Resources.StartURL);

            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            scenarioContext["WebDriver"] = driver;
        }


        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario

            var driver = scenarioContext["WebDriver"] as IWebDriver;
            if (scenarioContext.TestError != null)
            {
                TakeScreenshot(driver);
            }
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }

        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                                                    featureContext.FeatureInfo.Title.ToIdentifier(),
                                                    scenarioContext.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = (driver as ITakesScreenshot) ?? throw new NullReferenceException("Driver as screenshot should not be null.") ;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}