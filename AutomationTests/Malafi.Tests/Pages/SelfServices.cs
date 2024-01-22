using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace Malafi.Tests.Pages
{
    public class SelfServices
    {
        private WebDriverWait wait;
        private object errorMessage;


    
    public SelfServices(IWebDriver driver)
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        PageFactory.InitElements(driver,this);


    }
        public object ErrorMessage => errorMessage;
        public WebDriverWait Wait => wait ?? throw new NullReferenceException();



        [FindsBy(How = How.Id, Using= "loginButton")]
     public IWebElement Login { get; private set; }

}
}