using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace Malafi.Tests.Pages
{
    public class NewDocTypeApprovalLVI
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;



        public NewDocTypeApprovalLVI(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }


        public WebDriverWait Wait => wait;

        [FindsBy(How = How.Id, Using = "b3-Dropdown3")]
        public IWebElement AssignedToTypeBox { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-Dropdown3']/option[3]")]
        public IWebElement AssignedToTypeEmployee { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-Input_EmployeeId")]
        public IWebElement EmployeeBox { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".table-row:nth-child(1) .icon")]
        public IWebElement Employee { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary > span")]
        public IWebElement SaveClick { get; private set; }

        [FindsBy(How = How.ClassName, Using = "feedback-message-text")]
        public IWebElement FeedbackMessage { get; private set; }


        public void AddNewDocumentLVI()
        { 
       
            Wait.Until(ExpectedConditions.ElementToBeClickable(AssignedToTypeBox));
            var select = new SelectElement(AssignedToTypeBox);
            select.SelectByText("Employee");
            Wait.Until(ExpectedConditions.ElementToBeClickable(EmployeeBox)).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(Employee)).Click();
        }


        public void ClickSave()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(SaveClick)).Click();
            

        }
    }
}
