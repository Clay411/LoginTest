
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
        public bool isElementDisplayed(By elementSelector)
        {
            IWebElement element;

            bool isElementPresent = Driver.FindElements(elementSelector).Count > 0;

            if (isElementPresent)
            {
                element = Driver.FindElement(elementSelector);
            }
            else return false;

            return (element.Displayed && element.Enabled);

        }

    }
}
