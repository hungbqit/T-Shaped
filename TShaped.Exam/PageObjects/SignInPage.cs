using OpenQA.Selenium;
using TShaped.Common;

namespace TShaped.PageObjects
{
    public class SignInPage : BasePage
    {
        private readonly By emailTextBox = By.Id("email_create");
        private readonly By createButton = By.Id("SubmitCreate");

        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public AccountCreationPage InputEmailAndGoToAccountCreationPage(string email)
        {
            SendKeyToElement(emailTextBox, email);
            ClickToElement(createButton);
            return new AccountCreationPage(driver);
        }
    }
}
