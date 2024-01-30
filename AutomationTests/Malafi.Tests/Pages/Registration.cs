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

        public Registration(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait Wait { get => wait; private set => wait = value; }

     

        [FindsBy(How = How.Id, Using = "b3-DropdownNationality")]
        public IWebElement NationalityDropDown { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownJobTitleEn")]
        public IWebElement JobtitleDropDown { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn")]
        public IWebElement JobDropdownOrganizationalLevelEn { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn2")]
        public IWebElement JobDropdownOrganizationalLevelEn2 { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn3")]
        public IWebElement JobDropdownOrganizationalLevelEn3 { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownOrganizationalLevelEn4")]
        public IWebElement JobDropdownOrganizationalLevelEn4 { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-Dropdown2")]
        public IWebElement JobGroup { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-DropdownSpecialityEn")]
        public IWebElement DropdownSpecialityEn { get; internal set; }

        [FindsBy(How = How.Id, Using = "b3-Dropdown3")]
        public IWebElement ContractType { get; internal set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement SubmitButton { get; internal set; }

    }

}