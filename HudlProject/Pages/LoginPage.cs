
namespace HudlProject.Pages
{
    public class LoginPage
    {
        IWebDriver Driver { get; set; }

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Retrieves the stored valid credentials from a text file that needs created in the LoginTest folder.
        /// </summary>
        /// <param name="credentialField">Specifies the login field for which the value is needed. Must be value of email or password.</param>
        /// <returns>The valid email or password from the stored credential file depending on the value provided in the parameter.</returns>
        public String retrieveCredentials (String credentialField)
        {
            const String filePath = @"../../../../credentials.txt";
            String email = "";
            String password = "";

            int lineNumber = 0;

            foreach (String line in File.ReadLines(filePath))
            {
                if (lineNumber == 0)
                {
                    email = line;
                }
                else if (lineNumber == 1)
                {
                    password = line;    
                }   
                lineNumber++;
            }

            if (credentialField.ToLower().Equals("email"))
            {
                return email;
            }
            else if (credentialField.ToLower().Equals("password"))
            {
                return password;
            }
            else
            {
                Console.WriteLine("Invalid argument value passed to the retrieveCredentials function. Please use \"email\" or \"password\"");
                return "See console output";
            }
        }

        By emailField = By.Id("email");
        public void enterEmail(String emailAddress)
        {
            Driver.FindElement(emailField).SendKeys(emailAddress);
        }

        By passwordField = By.Id("password");
        public void enterPassword(String password)
        {
            Driver.FindElement(passwordField).SendKeys(password);
        }

        By loginButton = By.Id("logIn");
        public void clickLoginButton()
        {
            Driver.FindElement(loginButton).Click();
        }

    }
}
