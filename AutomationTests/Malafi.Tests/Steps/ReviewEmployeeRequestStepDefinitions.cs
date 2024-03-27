using Malafi.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
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
    public class ReviewEmployeeRequestStepDefinitions
    {
        private ScenarioContext scenarioContext;
        public ReviewEmployeeRequestStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
        }




        [Then(@"I should see  the  selected Status in  '([^']*)'")]
        public void ThenIShouldSeeTheSelectedStatusIn(string empStatus)
        {
            var reviewEmployeeRequestPage = scenarioContext["ReviewEmployeeRequest"] as ReviewEmployeeRequest;
            Assert.IsNotNull(reviewEmployeeRequestPage);
            SelectElement selectElement = new SelectElement(reviewEmployeeRequestPage.Status);
            Assert.AreEqual(selectElement.AllSelectedOptions[0].Text, empStatus);
            //reviewEmployeeRequestPage.Wait.Until(ExpectedConditions.ElementToBeClickable(reviewEmployeeRequestPage.Status));
        }



    }
}
