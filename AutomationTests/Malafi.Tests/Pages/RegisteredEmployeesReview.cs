using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malafi.Tests.Steps;
using SeleniumExtras.WaitHelpers;

namespace Malafi.Tests.Pages
{
    public class RegisteredEmployeesReview
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public RegisteredEmployeesReview(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;


        [FindsBy(How = How.XPath, Using = "//div[@id='b3-b1-MainContent']/div/table/tbody/tr/td[4]/div/div[3]/button/img")]
        public IWebElement EmployeeName { get; private set; }


        [FindsBy(How = How.CssSelector, Using = ".btn:nth-child(2)")]
        public IWebElement SaveChanges { get; private set; }


        [FindsBy(How = How.CssSelector, Using = ".swal2-confirm")]
        public IWebElement SaveChangesPopup { get; private set; }



        public void FormRegisteredEmployeesValidation()
        {


            wait.Until(ExpectedConditions.ElementToBeClickable(SaveChanges)).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(SaveChangesPopup)).Click();

        }
    }
}
