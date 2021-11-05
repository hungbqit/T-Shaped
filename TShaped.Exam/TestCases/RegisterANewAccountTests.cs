using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TShaped.Common;
using TShaped.PageObjects;

namespace TShaped.TestCases
{
    [TestFixture]
    class RegisterANewAccountTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private SignInPage _signInPage;
        private AccountCreationPage _accountCreationPage;
        private MyAccountPage _myAccountPage;

        [SetUp]
        public void Setup()
        {
            _driver = WebDriverService.CreateBrowserDriver("chrome");
            _driver.Navigate().GoToUrl(Constants.APP_URL);
        }

        [Test]
        public void RegisterANewAccountSuccessfully()
        {
            var validEmail = string.Format(Constants.EMAIL_FORMAT, DateTime.UtcNow.Ticks);

            _homePage = new HomePage(_driver);
            _signInPage = _homePage.GoToSignInPage();
            _accountCreationPage = _signInPage.InputEmailAndGoToAccountCreationPage(validEmail);

            _myAccountPage = _accountCreationPage.FillFormAndRegister(
                Constants.GENDER,
                Constants.FIRST_NAME,
                Constants.LAST_NAME,
                Constants.PASSWORD,
                Constants.DOB_DAY,
                Constants.DOB_MONTH,
                Constants.DOB_YEAR,
                Constants.SIGN_UP_NEWSLETTER,
                Constants.RECEIVE_SPECIAL_OFFERS,
                Constants.ADD_FIRST_NAME,
                Constants.ADD_LAST_NAME,
                Constants.ADD_COMPANY,
                Constants.ADD_ADDRESS,
                Constants.ADD_ADDRESS_2,
                Constants.ADD_CITY,
                Constants.ADD_STATE,
                Constants.ADD_POSTAL_CODE,
                Constants.ADD_COUNTRY,
                Constants.ADD_ADDITIONAL_INFORMATION,
                Constants.ADD_PHONE,
                Constants.ADD_MOBILE,
                Constants.ADD_ALIAS
             );

            var expectedAccountName = $"{Constants.FIRST_NAME} {Constants.LAST_NAME}";
            var accountName = _myAccountPage.GetAccountNameLabelValue();
            Assert.AreEqual(expectedAccountName, accountName, "Account name is not displayed as expected.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
