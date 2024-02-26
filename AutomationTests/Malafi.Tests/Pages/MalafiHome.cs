﻿using DocumentFormat.OpenXml.Bibliography;
using Malafi.Tests.Features;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;


namespace Malafi.Tests.Pages
{
    public class MalafiHome
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public MalafiHome(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".ThemeGrid_MarginGutter > .OSFillParent")]
        public IWebElement DocumentTypeLink { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='b2-PageLinks']/div[2]/a[5]/i")]
        public IWebElement EmployeesSearchLink { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#b2-PageLinks > div.hr-item-menu > a:nth-child(3)")]
        public IWebElement DocumentGroupLink { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".ThemeGrid_Width7 > span")]
        public IWebElement RequestReistrationButton { get; private set; }


        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Registered Employees')]")]
        public IWebElement RegisteredEmployeesLink { get; private set; }


        [FindsBy(How = How.LinkText, Using = "Dashboard")]
        public IWebElement DashboardLink { get; private set; }
        

        public WebDriverWait Wait => wait;

        public DocumentType ClickOnDocumentTypeLink()
        {
            DocumentTypeLink.Click();
            return new DocumentType(driver);
        }

        public EmployeesSearch ClickOnEmployeesSearch()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(EmployeesSearchLink)).Click();
            return new EmployeesSearch(driver);
        }
        public DocumentsGroup ClickOnDocumentGroupLink()
        {
            DocumentGroupLink.Click();
            return new DocumentsGroup(driver);
        }

        public RegisteredEmployees ClickOnRegisteredEmployees()
        {
            Thread.Sleep(900);
            Wait.Until(ExpectedConditions.ElementToBeClickable(RegisteredEmployeesLink)).Click();
            return new RegisteredEmployees(driver);
        }


        public Dashboards ClickOnExecutiveDashboard()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(DashboardLink)).Click();

            return new Dashboards(driver);
        }


        public Registration ClickOnRegistrationFormButton()
        {
            RequestReistrationButton.Click();
            return new Registration(driver);
        }
    }






}