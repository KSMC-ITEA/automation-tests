using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports.Reporter;
using Yaqeen.Tests.Pages;

namespace Yaqeen.Tests.Hooks
{
    [Binding]
    public class YaqeenHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public YaqeenHooks(FeatureContext fContext, ScenarioContext context)
        {
            scenarioContext = context;
            featureContext = fContext;
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = sc.StepContext.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(sc, null);
            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(sc.StepContext.StepInfo.Text);
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text).Fail(sc.TestError);
                if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text).Fail(sc.TestError);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text).Fail(sc.TestError);
                if (stepType == "And")
                    scenario.CreateNode<And>(sc.StepContext.StepInfo.Text).Fail(sc.TestError);
            }
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var scenarioTitle = scenarioContext.ScenarioInfo.Title
                + string.Join("_", scenarioContext.ScenarioInfo.Arguments.Values.OfType<string>().ToList());
            scenario = featureName.CreateNode<Scenario>(scenarioTitle);
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
            scenarioContext["LoginPage"] = new LoginPage(driver);
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

            var driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");
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

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var artifactDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "testresults");
            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);
            string fileNameBase = System.IO.Path.Combine(artifactDirectory, string.Format("report_{0}.html", DateTime.Now.ToString("yyyyMMdd_HHmmss")));
            var htmlReporter = new ExtentSparkReporter(fileNameBase);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = "error", artifactDirectory;
                PrepareFile(ref fileNameBase, out artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = System.IO.Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = (driver as ITakesScreenshot) ?? throw new NullReferenceException("Driver as screenshot should not be null.");

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = System.IO.Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }

        private void PrepareFile(ref string fileNameBase, out string artifactDirectory)
        {
            fileNameBase = string.Format(fileNameBase + "_{0}_{1}_{2}",
                                                                featureContext.FeatureInfo.Title.ToIdentifier(),
                                                                scenarioContext.ScenarioInfo.Title.ToIdentifier(),
                                                                DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            artifactDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "testresults");
            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);
        }
    }
}
