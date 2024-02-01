using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Malafi.Tests.Pages
{
    public class RegisteredEmployees
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public RegisteredEmployees(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;

        [FindsBy(How = How.XPath, Using = "//input[@id='b3-RadioButton2-input']")]
        public IWebElement Approved { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='b3-b1-MainContent']/div/table/tbody/tr/td[4]/div/div[3]/button/img")]
        public IWebElement Review { get; private set; }




        public RegisteredEmployeesReview ClickOnReviewEmployees()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(Approved)).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(Review)).Click();
            return new RegisteredEmployeesReview(driver);


        }
    }
}
