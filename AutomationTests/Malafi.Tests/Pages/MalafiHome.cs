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


        [FindsBy(How = How.LinkText, Using = "Documents Group")]
        public IWebElement DocumentGroupLink { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".ThemeGrid_Width7 > span")]
        public IWebElement RequestReistrationButton { get; private set; }


        public WebDriverWait Wait => wait;

        public DocumentType ClickOnDocumentTypeLink()
        {
            DocumentTypeLink.Click();
            return new DocumentType(driver);
        }
        public DocumentsGroup ClickOnDocumentGroupLink()
        {
            DocumentGroupLink.Click();
            return new DocumentsGroup(driver);
        }

        public Registration ClickOnRegistrationFormButton()
        {
            RequestReistrationButton.Click();
            return new Registration(driver);
        }
    }






}