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

        /// <summary>
        /// Test1 verifies a valid user can login.
        /// </summary>
        [Test]
        public void Test1ValidLogin()
        {
            LandingPage landingPage = new LandingPage(driver);
            landingPage.clickLoginButton();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.enterEmail(loginPage.retrieveCredentials("email"));
            loginPage.enterPassword(loginPage.retrieveCredentials("password"));
            loginPage.clickLoginButton();

            UserHomePage userHomePage = new UserHomePage(driver);
            //Verify login was successful
            Assert.IsTrue(userHomePage.isCurrentPage());
        }

        /// <summary>
        /// Test2 verifies the invalid login message displays for a login attempt with a valid email and invalid password.
        /// </summary>
        [Test]
        public void Test2InvalidPassword()
        {
            LandingPage landingPage = new LandingPage(driver);
            landingPage.clickLoginButton();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.enterEmail(loginPage.retrieveCredentials("email"));
            loginPage.enterPassword("Abc1234");
            loginPage.clickLoginButton();
            //wait for the invalid login message to display on the page.
            SpinWait.SpinUntil(() => loginPage.isElementDisplayed(loginPage.loginErrorMessage), 5000);
            //Validate the invalid login message text displays expected message.
            Assert.IsTrue(loginPage.getDisplayedLoginErrorMessageText().Equals(loginPage.desiredInvalidLoginMessage));
        }

        /// <summary>
        /// Test3 verifies the invalid login message displays when clicking the Login button without enterng credentials.
        /// </summary>
        [Test]
        public void Test3EmptyLogin()
        {
            LandingPage landingPage = new LandingPage(driver);
            landingPage.clickLoginButton();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.clickLoginButton();

            SpinWait.SpinUntil(() => loginPage.isElementDisplayed(loginPage.loginErrorMessage), 5000);
            //Validate the invalid login message text displays expected message.
            Assert.IsTrue(loginPage.getDisplayedLoginErrorMessageText().Equals(loginPage.desiredInvalidLoginMessage));
        }

        /// <summary>
        /// Test4 verifies the invalid login message displays when logging in with an invalid email and a valid password.
        /// </summary>
        [Test]
        public void Test4InvalidEmail()
        {
            LandingPage landingPage = new LandingPage(driver);
            landingPage.clickLoginButton();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.enterEmail("clayton.pfeifer@test.com");
            loginPage.enterPassword(loginPage.retrieveCredentials("password"));
            loginPage.clickLoginButton();
            //wait for the invalid login message to display on the page.
            SpinWait.SpinUntil(() => loginPage.isElementDisplayed(loginPage.loginErrorMessage), 5000);
            //Validate the invalid login message text displays expected message.
            Assert.IsTrue(loginPage.getDisplayedLoginErrorMessageText().Equals(loginPage.desiredInvalidLoginMessage));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}