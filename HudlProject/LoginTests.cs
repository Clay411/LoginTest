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
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            basePage = new BasePage(driver);
        }

        [Test]
        public void Test1()
        {
            HomePage homePage = new HomePage(driver);
            homePage.clickLogin();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}