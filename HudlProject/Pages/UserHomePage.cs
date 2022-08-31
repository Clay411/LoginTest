namespace HudlProject.Pages
{
    public class UserHomePage
    {
        IWebDriver Driver { get; set; }

        public UserHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        const string pageIdentifierSelector = "search-bar";

        public Boolean isCurrentPage()
        {
            Boolean isCurrentPage = Driver.FindElements(By.ClassName(pageIdentifierSelector)).Count > 0;
            return isCurrentPage;
        }
        
    }
}
