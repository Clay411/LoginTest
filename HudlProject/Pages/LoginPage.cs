namespace HudlProject.Pages
{
    public class LoginPage : BasePage
    {
        By emailField = By.Id("email");
        By passwordField = By.Id("password");
        By loginButton = By.Id("logIn");
        public By loginErrorMessage { get; } = By.CssSelector("p[data-qa-id=\"error-display\"]");
        public String desiredInvalidLoginMessage {get;} = "We didn't recognize that email and/or password.Need help?";

        public LoginPage(IWebDriver driver) : base(driver)
        {
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

        
        public void enterEmail(String emailAddress)
        {
            Driver.FindElement(emailField).SendKeys(emailAddress);
        }

        public void enterPassword(String password)
        {
            Driver.FindElement(passwordField).SendKeys(password);
        }

        public void clickLoginButton()
        {
            Driver.FindElement(loginButton).Click();
        }

        /// <summary>
        /// A function to get the text of the login error message element displayed after invalid login attempt.
        /// </summary>
        /// <returns>The text of the login error message element.</returns>
        public String getDisplayedLoginErrorMessageText()
        {
            string elementText = Driver.FindElement(loginErrorMessage).Text;
            return elementText;
        }

    }
}
