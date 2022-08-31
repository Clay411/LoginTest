namespace HudlProject.Pages
{
    public class UserHomePage
    {
        IWebDriver Driver { get; set; }

        const string pageIdentifierSelector = "search-bar";

        public UserHomePage(IWebDriver driver)
        {
            Driver = driver;
        }


        public bool isCurrentPage()
        {
            bool isCurrentPage = Driver.FindElements(By.ClassName(pageIdentifierSelector)).Count > 0;
            return isCurrentPage;
        }
        
    }
}
