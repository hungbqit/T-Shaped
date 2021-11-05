using OpenQA.Selenium;
using TShaped.Common;

namespace TShaped.PageObjects
{
    public class CategoryPage : BasePage
    {
        private readonly By firstProductSelector = By.CssSelector(".product_list > li:first-of-type");
        private readonly By productNameLink = By.CssSelector(".product-name");
        private readonly By addToCartButton = By.CssSelector(".ajax_add_to_cart_button");

        public CategoryPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement GetFirstProductElement()
        {
            WaitForElementExists(firstProductSelector);
            return FindElement(firstProductSelector);
        }

        public string GetFirstProductDisplayedText()
        {
            var element = GetFirstProductElement();
            return element.Text;
        }

        public string GetFirstProductNameValue()
        {
            var element = GetFirstProductElement();
            var link = element.FindElement(productNameLink);
            return link.Text;
        }

        public int? GetFirstProductIdValue()
        {
            var element = GetFirstProductElement();
            var button = element.FindElement(addToCartButton);
            return int.TryParse(button.GetAttribute("data-id-product"), out int id) ? id : null;
        }
    }
}
