using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace Malafi.Tests.Pages
{
    public class Registration
    {
        public IWebDriver driver;
        private WebDriverWait wait;
        private Dictionary<string, IWebElement> validationObjects;

        public Registration(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
            validationObjects = new Dictionary<string, IWebElement>();
            validationObjects.Add("Email", EmailValidation);
            validationObjects.Add("Mobile", MobileValidation);
            validationObjects.Add("JobNumber", JobNumberValidation);

        }

        public WebDriverWait Wait { get => wait; private set => wait = value; }
        public Dictionary<string, IWebElement> ValidationObjects => validationObjects;


        [FindsBy(How = How.Id, Using = "b3-DropdownNationality")]
        public IWebElement NationalityDropDown { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownJobTitleEn")]
        public IWebElement JobTitleDropDown { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn")]
        public IWebElement JobDropdownOrganizationalLevelEn { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn2")]
        public IWebElement JobDropdownOrganizationalLevelEn2 { get; internal set; }

        //[FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn3")]
        //public IWebElement JobDropdownOrganizationalLevelEn3 { get; internal set; }

        //[FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn4")]
        //public IWebElement JobDropdownOrganizationalLevelEn4 { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-Dropdown2")]
        public IWebElement JobGroup { get; internal set; }

        //[FindsBy(How = How.Id, Using = "b3-DropdownSpecialityEn")]
        //public IWebElement DropdownSpecialityEn { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-Dropdown3")]
        public IWebElement ContractType { get; internal set; }

        [FindsBy(How=How.Id, Using="b3-Dropdown1-container")]
        public IWebElement RequestStatus { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement SubmitButton { get; internal set; }

        [FindsBy(How = How.ClassName, Using = "feedback-message")]
        public IWebElement SuccessMessage { get; private set; }
        [FindsBy(How = How.Id, Using = "b3-Input_EmployeeEmail_DescribedBy")]
        public IWebElement EmailValidation { get; private set; }

        [FindsBy(How = How.Id, Using = "b3-Input_Phone_DescribedBy")]
        public IWebElement MobileValidation { get; private set; }

        [FindsBy(How=How.Id,Using = "b3-Input_JobNumber")]
        public IWebElement JobNumberValidation { get; private set; }
    }

}