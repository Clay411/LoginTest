
namespace HudlProject.Pages
{
     public class BasePage
    {
        protected static IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        /// <summary>
        /// A function to verify an element is displayed on the page and enabled.
        /// </summary>
        /// <param name="elementSelector">The selector of the element to check displayed status.</param>
        /// <returns></returns>
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
