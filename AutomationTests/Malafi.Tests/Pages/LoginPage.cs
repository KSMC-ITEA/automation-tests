using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malafi.Tests.Pages
{

    //هذه الصفحة تمثل كلاس لصفحة اللوقين راح نرجع نستخدمة 
    public class LoginPage
    {

        #region Fields
        private IWebDriver driver;
        public WebDriverWait Wait;
        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "b2-UsernameInput")]
        public IWebElement UserName { get; private set; }

        #endregion

        #region Properties
        [FindsBy(How = How.Id, Using = "b2-PasswordInput")]
        public IWebElement PasswordTextBox { get; private set; }
        [FindsBy(How = How.Id, Using = "b2-PasswordInput")]
        public IWebElement PasswordValue { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement LoginButton { get; private set; }
        #endregion
     

        public HomePage Login()
        {
            this.Wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginButton));
            this.LoginButton.Click();

            return new HomePage(driver);
        }

        /*  public LoginPage(IWebDriver driver)
          {
              this.driver = driver;
              wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

              //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
              PageFactory.InitElements(driver, this);
          }*/

        #region Page Navigation Methods
        /*        public UserProfile Login()
               {
                   this.wait.Until(ExpectedConditions.ElementToBeClickable(this.LoginButton));
                   this.LoginButton.Click();

                   return new UserProfile(driver);
               }*/
        #endregion

    }
}