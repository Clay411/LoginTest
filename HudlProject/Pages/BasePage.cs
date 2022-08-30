
using OpenQA.Selenium.Chrome;

namespace HudlProject.Pages
{
     public class BasePage
    {
        protected static IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
