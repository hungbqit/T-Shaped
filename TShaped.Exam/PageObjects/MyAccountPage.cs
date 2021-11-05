using OpenQA.Selenium;
using TShaped.Common;

namespace TShaped.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private readonly By accountNameLabel = By.CssSelector(".header_user_info > a.account > span");

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetAccountNameLabelValue()
        {
            WaitForElementVisible(accountNameLabel);
            return GetElementText(accountNameLabel);
        }
    }
}
