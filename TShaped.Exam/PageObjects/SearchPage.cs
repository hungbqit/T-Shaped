using OpenQA.Selenium;
using TShaped.Common;

namespace TShaped.PageObjects
{
    public class SearchPage : BasePage
    {
        private readonly By productLi = By.CssSelector(".product_list > li");
        private readonly By productNameLink = By.CssSelector(".product-name");
        private readonly By addToCartButton = By.CssSelector(".ajax_add_to_cart_button");

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public string FindProductElementByIdAndName(int id, string name)
        {
            WaitForElementVisible(productLi);
            var elements = FindElements(productLi);
            foreach (var element in elements)
            {
                var link = element.FindElement(productNameLink);
                var button = element.FindElement(addToCartButton);
                var productName = link.Text;
                int? productId = int.TryParse(button.GetAttribute("data-id-product"), out int value) ? value : null;
                if (productId != null && productId.Value == id && productName.Equals(name))
                {
                    // Return displayed text of matched product
                    return element.Text;
                }
            }
            return null;
        }
    }
}
