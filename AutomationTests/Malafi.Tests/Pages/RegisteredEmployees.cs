using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Malafi.Tests.Pages
{
    public class RegisteredEmployees
    {


        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private Dictionary<string, IWebElement> status;
        private  string statusvar;
        public RegisteredEmployees(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

            NewStatus = new Dictionary<string, IWebElement>();
            /// key of the dictionay key,value 
            NewStatus.Add("Pending", PendingStatus);
            NewStatus.Add("Approved", ApprovedStatus);
            NewStatus.Add("Rejected", RejectedStatus);


        }
        public WebDriverWait Wait => wait;

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b1-Title']/h1/span")]
        public IWebElement RegisteredEmployeesButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b1-MainContent']/div/table/tbody/tr[1]/td[4]/div/div[1]/button/i")]
        public IWebElement AddButton { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-RadioButton2-input")]
        public IWebElement ApprovedStatus { get; private set; }


        [FindsBy(How = How.Id, Using = "b3-RadioButton3-input")]
        public IWebElement RejectedStatus { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-RadioButton1-input")]
        public IWebElement PendingStatus { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b3-b1-MainContent > div > table > tbody > tr > td:nth-child(4) > div > button > img")]
        public IWebElement ReviewButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='b3-b1-MainContent']/div/table/tbody/tr[1]/td[4]/div/div[3]")]
           public IWebElement ApprovedReviewButton { get; private set; }

        public Dictionary<string, IWebElement> NewStatus { get => status; private set => status = value; }
        public ReviewEmployeeRequest ClickOnEmployeeRequest()

        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(ReviewButton)).Click();
            return new ReviewEmployeeRequest(driver);
        }

     


        public void GiveTheSelectedStatus(string EmpStatus)
        {
            NewStatus[EmpStatus].Click();


        }

        public ReviewEmployeeRequest ClickOnReviewButton ()
        {
            Thread.Sleep(500);                           
           
                ReviewButton.Click();
               
            var reviewPage = new ReviewEmployeeRequest(driver);
            return reviewPage;
        }

      

        public ReviewEmployeeRequest ClickOnApprovedReviewButton()
        {
            Thread.Sleep(500);
            ApprovedReviewButton.Click();

            var reviewPage = new ReviewEmployeeRequest(driver);

            return reviewPage;
        }

        public void GiveTheApprovedEmployees()
        {

            ApprovedStatus.Click();

}
        public AddQualificationGroups ClickOnAddIcon ()
        {

            Thread.Sleep(500);
            AddButton.Click();
            var addQualificationGroups = new AddQualificationGroups(driver);
            return addQualificationGroups;

        }


    }  

}
