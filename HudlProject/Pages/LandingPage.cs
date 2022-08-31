
namespace HudlProject.Pages
{
    public class LandingPage
    {
        IWebDriver Driver { get; set; }

        //private IWebElement btnLogin = Driver.FindElement(By.Id("login"));
        public LandingPage(IWebDriver driver)
        {
            Driver = driver;
        }

        By loginButton = By.CssSelector("a[data-qa-id=\"login\"]");
        public void clickLogin()
        {
            Driver.FindElement(loginButton).Click();
        }
        
    }
}
