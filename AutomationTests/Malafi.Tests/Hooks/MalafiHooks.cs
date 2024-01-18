using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;
using System.Reflection;

namespace Malafi.Tests.Hooks
{
    //[Binding]
    public sealed class MalafiHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private ScenarioContext scenarioContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public MalafiHooks(ScenarioContext context)
        {
            scenarioContext = context;
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
            driver.Close();
            driver.Dispose();
        }
    }
}