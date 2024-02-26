using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Configuration;

namespace Malafi.Tests.Pages
{
    public class EmployeesSearch
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public EmployeesSearch(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait => wait;

        [FindsBy(How = How.CssSelector, Using = ".fa-download:nth-child(1)")]
        public IWebElement Excel { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-b5-Column1")]
        public IWebElement EmployeesSearchVLD { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='$b3']/div/div[5]/table")]
        public IWebElement EmployeesTable { get; private set; }


        public void ClickOnReviewEmployees()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(Excel)).Click();

        }


    }
}
