using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TShaped.Common;

namespace TShaped.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly By signInButton = By.CssSelector(".login");

        private readonly By searchTextBox = By.Id("search_query_top");
        private readonly By searchButton = By.CssSelector(".button-search");

        private static By GetMenuSelectorByTitle(string title) => By.XPath($"//div[@id='block_top_menu']//a[@title='{title}']");
        private static By GetSubMenuSelectorByTitle(string title) => By.XPath($"following-sibling::*//a[@title='{title}']");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public SignInPage GoToSignInPage()
        {
            ClickToElement(signInButton);
            return new SignInPage(driver);
        }

        public CategoryPage MoveCursorOverAMenuAndClickOnASubMenu(string menuTitle, string subMenuTitle)
        {
            var action = new Actions(driver);

            var menu = FindElement(GetMenuSelectorByTitle(menuTitle));
            var subMenu = menu.FindElement(GetSubMenuSelectorByTitle(subMenuTitle));
            action.MoveToElement(menu).MoveToElement(subMenu).Click().Build().Perform();

            return new CategoryPage(driver);
        }

        public SearchPage InputKeywordAndSearch(string keyword)
        {
            SendKeyToElement(searchTextBox, keyword);
            ClickToElement(searchButton);
            return new SearchPage(driver);
        }
    }
}
