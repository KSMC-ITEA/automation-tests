﻿using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class HomePageFeatureStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;

        public HomePageFeatureStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver;

        }
        [When(@"Click on Malafi link")]
        public void WhenClickOnMalafiLink()
        {
            var homePage = scenarioContext["HomePage"] as HomePage;
            Assert.IsNotNull(homePage);
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
