using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TShaped.Common
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IList<IWebElement> FindElements(By locator)
        {
            return driver.FindElements(locator);
        }

        public void ClickToElement(By locator)
        {
            FindElement(locator).Click();
        }

        public void SendKeyToElement(By locator, string value)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(value);
        }

        public string GetElementText(By locator)
        {
            return FindElement(locator).Text;
        }

        public static string GetElementText(IWebElement element)
        {
            return element.Text;
        }

        public static void SleepInSeconds(int time)
        {
            try
            {
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException e)
            {
                e.StackTrace.ToString();

            }
        }

        public void WaitForElementVisible(By locator)
        {
            var explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));
            explicitWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementExists(By locator)
        {
            var explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));
            explicitWait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementInvisible(By locator)
        {
            var explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));
            explicitWait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitForElementClickable(By locator)
        {
            var explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));
            explicitWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }

    
}
