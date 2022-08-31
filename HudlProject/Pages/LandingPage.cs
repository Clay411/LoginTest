﻿
namespace HudlProject.Pages
{
    public class LandingPage
    {
        IWebDriver Driver { get; set; }

        By loginButton = By.CssSelector("a[data-qa-id=\"login\"]");

        public LandingPage(IWebDriver driver)
        {
            Driver = driver;
        }
        
        public void clickLogin()
        {
            Driver.FindElement(loginButton).Click();
        }
        
    }
}
