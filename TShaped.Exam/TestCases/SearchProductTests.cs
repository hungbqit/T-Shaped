using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TShaped.Common;
using TShaped.PageObjects;

namespace TShaped.TestCases
{
    [TestFixture]
    class SearchProductTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private CategoryPage _categoryPage;
        private SearchPage _searchPage;

        [SetUp]
        public void Setup()
        {
            _driver = WebDriverService.CreateBrowserDriver("chrome");
            _driver.Navigate().GoToUrl(Constants.APP_URL);
        }

        [TestCase("Women", "T-shirts")]
        [TestCase("Women", "Evening Dresses")]
        public void SearchProductSuccessfully(string menuTitle, string subMenuTitle)
        {
            _homePage = new HomePage(_driver);
            _categoryPage = _homePage.MoveCursorOverAMenuAndClickOnASubMenu(menuTitle, subMenuTitle);

            var firstProductDisplayedText = _categoryPage.GetFirstProductDisplayedText();
            var firstProductName = _categoryPage.GetFirstProductNameValue();
            var firstProductId = _categoryPage.GetFirstProductIdValue();
            Assert.IsNotNull(firstProductId, "The product's id is null.");

            _searchPage = _homePage.InputKeywordAndSearch(firstProductName);
            var resultDisplayedText = _searchPage.FindProductElementByIdAndName(firstProductId.Value, firstProductName);
            Assert.IsNotNull(resultDisplayedText, "Not found.");

            Assert.AreEqual(firstProductDisplayedText, resultDisplayedText, "The displayed product is not the same details as expected.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
