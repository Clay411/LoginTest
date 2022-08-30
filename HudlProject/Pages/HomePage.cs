
namespace HudlProject.Pages
{
    public class HomePage
    {
        IWebDriver Driver { get; set; }

        //private IWebElement btnLogin = Driver.FindElement(By.Id("login"));
        public HomePage(IWebDriver driver)
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
