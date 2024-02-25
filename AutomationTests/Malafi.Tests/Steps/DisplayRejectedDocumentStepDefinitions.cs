using DocumentFormat.OpenXml.Bibliography;
using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class DisplayRejectedDocumentStepDefinitions
    {
        private ScenarioContext scenarioContext;
        private RegisteredEmployees registeredEmployees;
        private IWebDriver driver;

        public DisplayRejectedDocumentStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");

        }

        [When(@"I click on Approved")]
        public void WhenIClickOnApproved()
        {
            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            malafiHome.Wait.Until(ExpectedConditions.ElementToBeClickable(malafiHome.RegisteredEmployeesLink));
            Thread.Sleep(100);
            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();
            registeredEmployees.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployees.Approved)).Click();
        }

        [When(@"I click on view documents")]
        public void WhenIClickOnViewDocuments()
        {
            Thread.Sleep(100);

            registeredEmployees.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployees.ViewDoc)).Click();

        }

        [When(@"I click any file")]
        public void WhenIClickAnyFile()
        {
            Thread.Sleep(1000);
            registeredEmployees.TitleWrapper.Click();
        }

        [When(@"Click on view documents")]
        public void WhenClickOnViewDocuments()
        {
            Thread.Sleep(1000);

            registeredEmployees.ViewDoc2.Click();

        }

        [When(@"I click on view Approved timeline")]
        public void WhenIClickOnViewApprovedTimeline()
        {
            Thread.Sleep(1000);

            registeredEmployees.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployees.ViewApprovalTimline)).Click();
            Thread.Sleep(1000);

        }

        [Then(@"I shoed see View Document Approval LVI History")]
        public void ThenIShoedSeeViewDocumentApprovalLVIHistory()
        {

            Assert.AreEqual("1079039804", registeredEmployees.NumberEmployeeIdVLD.Text);

            Assert.AreEqual("Testdocument_Ali S. Alharthi", registeredEmployees.NameEmployeeIdVLD.Text);

            Assert.AreEqual("Approved", registeredEmployees.DataExpressiondVLD.Text);
        }

        [Given(@"I click on DownloadPreviouslyUploadedFile")]
        public void GivenIClickOnDownloadPreviouslyUploadedFile()
        {
            Thread.Sleep(1000);
            registeredEmployees.TitleWrapperDisplay.Click();

            Thread.Sleep(1000);

            registeredEmployees.ViewDocDisplay.Click();


            registeredEmployees.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployees.DownloadPreviouslyUploadedFile)).Click();

        }

    }
}
