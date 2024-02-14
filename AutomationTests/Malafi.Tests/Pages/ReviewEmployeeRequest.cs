using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malafi.Tests.Pages
{
    public class ReviewEmployeeRequest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public ReviewEmployeeRequest(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }

        public WebDriverWait Wait => wait;

        [FindsBy(How = How.Id, Using = "b3-Dropdown2")]
        public IWebElement Status { get; private set; }

        /* [FindsBy(How = How.XPath, Using = "//*[@id='b3-StatusAndRejectionReason']/div[1]/label/span")]
         public IWebElement Statusfield { get; private set; }
 */

    }

}
