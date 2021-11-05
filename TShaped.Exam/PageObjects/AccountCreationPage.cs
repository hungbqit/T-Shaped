using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TShaped.Common;

namespace TShaped.PageObjects
{
    public class AccountCreationPage : BasePage
    {
        private readonly By maleGenderRadio = By.Id("id_gender1");
        private readonly By femaleGenderRadio = By.Id("id_gender2");
        private readonly By firstNameTextBox = By.Id("customer_firstname");
        private readonly By lastNameTextBox = By.Id("customer_lastname");
        private readonly By passwordTextBox = By.Id("passwd");
        private readonly By dayOfBirthSelect = By.Id("days");
        private readonly By monthOfBirthSelect = By.Id("months");
        private readonly By yearOfBirthSelect = By.Id("years");
        private readonly By newsletterCheckbox = By.Id("uniform-newsletter");
        private readonly By optinCheckbox = By.Id("uniform-optin");
        private readonly By addressFirstNameTextBox = By.Id("firstname");
        private readonly By addressLastNameTextBox = By.Id("lastname");
        private readonly By addressCompanyTextBox = By.Id("company");
        private readonly By addressLine1TextBox = By.Id("address1");
        private readonly By addressLine2TextBox = By.Id("address2");
        private readonly By addressCityTextBox = By.Id("city");
        private readonly By addressStateSelect = By.Id("id_state");
        private readonly By addressPostcodeTextBox = By.Id("postcode");
        private readonly By addressCountrySelect = By.Id("id_country");
        private readonly By additionalInformationTextArea = By.Id("other");
        private readonly By homePhoneTextBox = By.Id("phone");
        private readonly By mobilePhoneTextBox = By.Id("phone_mobile");
        private readonly By aliasTextBox = By.Id("alias");

        private readonly By registerButton = By.Id("submitAccount");

        public AccountCreationPage(IWebDriver driver) : base(driver)
        {
        }

        public MyAccountPage FillFormAndRegister(
            Gender gender,
            string firstName,
            string lastName,
            string password,
            int dayOfBirth,
            int monthOfBirth,
            int yearOfBirth,
            bool signUpForNewsletter,
            bool receiveSpecialOffers,
            string addressFirstName,
            string addressLastName,
            string addressCompany,
            string addressLine1,
            string addressLine2,
            string addressCity,
            string addressState,
            string addressPostcode,
            string addressCountry,
            string additionalInformation,
            string homePhone,
            string mobilePhone,
            string alias)
        {
            #region Fill data

            WaitForElementVisible(gender == Gender.Male ? maleGenderRadio : femaleGenderRadio);
            ClickToElement(gender == Gender.Male ? maleGenderRadio : femaleGenderRadio);

            WaitForElementVisible(firstNameTextBox);
            SendKeyToElement(firstNameTextBox, firstName);

            WaitForElementVisible(lastNameTextBox);
            SendKeyToElement(lastNameTextBox, lastName);

            WaitForElementVisible(passwordTextBox);
            SendKeyToElement(passwordTextBox, password);

            //WaitForElementVisible(dayOfBirthSelect);
            var days = new SelectElement(FindElement(dayOfBirthSelect));
            days.SelectByValue(dayOfBirth.ToString());

            //WaitForElementVisible(monthOfBirthSelect);
            var months = new SelectElement(FindElement(monthOfBirthSelect));
            months.SelectByValue(monthOfBirth.ToString());

            //WaitForElementVisible(yearOfBirthSelect);
            var years = new SelectElement(FindElement(yearOfBirthSelect));
            years.SelectByValue(yearOfBirth.ToString());

            if (signUpForNewsletter)
            {
                WaitForElementVisible(newsletterCheckbox);
                ClickToElement(newsletterCheckbox);
            }

            if (receiveSpecialOffers)
            {
                WaitForElementVisible(optinCheckbox);
                ClickToElement(optinCheckbox);
            }

            WaitForElementVisible(addressFirstNameTextBox);
            SendKeyToElement(addressFirstNameTextBox, addressFirstName);

            WaitForElementVisible(addressLastNameTextBox);
            SendKeyToElement(addressLastNameTextBox, addressLastName);

            WaitForElementVisible(addressCompanyTextBox);
            SendKeyToElement(addressCompanyTextBox, addressCompany);

            WaitForElementVisible(addressLine1TextBox);
            SendKeyToElement(addressLine1TextBox, addressLine1);

            WaitForElementVisible(addressLine2TextBox);
            SendKeyToElement(addressLine2TextBox, addressLine2);

            WaitForElementVisible(addressCityTextBox);
            SendKeyToElement(addressCityTextBox, addressCity);

            //WaitForElementVisible(addressStateSelect);
            var states = new SelectElement(FindElement(addressStateSelect));
            states.SelectByText(addressState);

            WaitForElementVisible(addressPostcodeTextBox);
            SendKeyToElement(addressPostcodeTextBox, addressPostcode);

            //WaitForElementVisible(addressCountrySelect);
            var countries = new SelectElement(FindElement(addressCountrySelect));
            countries.SelectByText(addressCountry);

            WaitForElementVisible(additionalInformationTextArea);
            SendKeyToElement(additionalInformationTextArea, additionalInformation);

            WaitForElementVisible(homePhoneTextBox);
            SendKeyToElement(homePhoneTextBox, homePhone);

            WaitForElementVisible(mobilePhoneTextBox);
            SendKeyToElement(mobilePhoneTextBox, mobilePhone);

            WaitForElementVisible(aliasTextBox);
            SendKeyToElement(aliasTextBox, alias);

            #endregion

            ClickToElement(registerButton);
            return new MyAccountPage(driver);
        }
    }
}
