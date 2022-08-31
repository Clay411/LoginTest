using HudlProject.Pages;
using OpenQA.Selenium.Chrome;

namespace HudlProject
{
    public class LoginTests
    {
        BasePage basePage;
        private static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            String baseUrl = "https://www.hudl.com/";
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            basePage = new BasePage(driver);
        }

        [Test]
        public void Test1ValidLogin()
        {
            LandingPage landingPage = new LandingPage(driver);
            landingPage.clickLogin();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.enterEmail(loginPage.retrieveCredentials("email"));
            loginPage.enterPassword(loginPage.retrieveCredentials("password"));
            loginPage.clickLoginButton();

            UserHomePage userHomePage = new UserHomePage(driver);
            
            Assert.IsTrue(userHomePage.isCurrentPage());
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}