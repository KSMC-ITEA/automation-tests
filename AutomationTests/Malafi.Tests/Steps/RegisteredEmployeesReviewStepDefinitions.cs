//using Malafi.Tests.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;
//using System.Xml.Linq;
//using TechTalk.SpecFlow;

//namespace Malafi.Tests.Steps
//{
//    [Binding]
//    public class RegisteredEmployeesReviewStepDefinitions
//    {
//        private readonly ScenarioContext context;
//        private IWebDriver driver;
//        private RegisteredEmployeesReview registeredEmployeesReview;
//        private RegisteredEmployees  registeredEmployees;

//        public RegisteredEmployeesReviewStepDefinitions(ScenarioContext context)
//        {
//            this.context = context;
//            registeredEmployeesReview = context["RegisteredEmployeesReview"] as DocumentsTypeDetails ?? throw new NullReferenceException();

//        }

//        [When(@"I click on  Review  button")]
//        public void WhenIClickOnReviewButton()
//        {
//            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
//            Assert.IsNotNull(malafiHome);
//            registeredEmployees = malafiHome.ClickOnRegisteredEmployees();
//            registeredEmployees.ClickOnReviewEmployees();
//            Thread.Sleep(1000);
//        }
//        [Then(@"I should be navigated to  Review  Page")]
//        public void ThenIShouldBeNavigatedToReviewPage()
//        {
//            var registeredEmployeesReview = scenarioContext["RegisteredEmployeesReview"] as RegisteredEmployeesReview;
//            Assert.IsNotNull(registeredEmployeesReview);
//            registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.SaveChanges));
//            Assert.IsTrue(registeredEmployeesReview.SaveChanges.Displayed);
//        }

//        [When(@"I click on  Employee Name Changing the name")]
//        public void WhenIClickOnEmployeeNameChangingTheName()
//        {
//            registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.EmployeeName)).Click();
//        }
//        [When(@"I click on Save Changes")]
//        public void WhenIClickOnSaveChanges()
//        {
//           registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.SaveChanges)).Click();

//           registeredEmployeesReview.Wait.Until(ExpectedConditions.ElementToBeClickable(registeredEmployeesReview.SaveChangesPopup)).Click();
//        }

//        [Then(@"It is supposed to be for readers only")]
//        public void ThenItIsSupposedToBeForReadersOnly()
//        {
//            Assert.IsFalse(Equals(registeredEmployeesReview.EmployeeName));
//        }

//    }
//}
