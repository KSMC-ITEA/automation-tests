using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Malafi.Tests.Pages
{

    public class HomePage
    {

        private WebDriverWait wait; 
        private object errorMessage;

        public HomePage(IWebDriver driver)
        {
           

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);

        }
        // نعرف خاصية نوعها ببليك لان ماينفع نستخدم عناصر الكلاس مباشره 
        public object ErrorMessage =>errorMessage;
        public WebDriverWait Wait => wait ?? throw new NullReferenceException();

        [FindsBy(How = How.CssSelector, Using = ".main-nav-profile > .ThemeGrid_MarginGutter")]
        public IWebElement FullName { get; private set; }

    }
}
    
