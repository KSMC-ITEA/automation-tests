﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Compensation.Tests
{
    [Binding]
    public sealed class CompensationHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private ScenarioContext scenarioContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public CompensationHooks(ScenarioContext context)
        {
            scenarioContext = context;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver; //= new ChromeDriver();
            switch (ConfigurationManager.AppSettings["Browser"])
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
            driver.Navigate().GoToUrl("https://devtest.ksmc.med.sa/Research/Login.aspx");

            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            scenarioContext["WebDriver"] = driver;
        }



        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver") ;
            driver.Close();
            driver.Dispose();
        }
    }
}