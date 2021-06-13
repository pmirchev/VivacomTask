using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using VivacomQAAutomationTask.Base;

namespace VivacomQAAutomationTask.Pages
{
    public class ShoppingCardPage : BasePage
    {
        public ShoppingCardPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => ("https://www.vivacom.bg/online/bg/shop/shopping-cart");

        public IWebElement PageTitle => Driver.FindElement(By.XPath("//*[normalize-space(text())='Моята кошница']"));

        public IWebElement FinalPrice => Driver.FindElement(By.CssSelector("#shopping-cart-span > div.container.main-content > aside > div.summarize-order > div > div.row.final-price > span.e-care-home-big-bill-price-digits.js-limit-exceed"));

        public List<IWebElement> RemoveProductButtons => Driver.FindElements(By.XPath("//*[@class='jsRemoveItemForm']/button")).ToList();

        public IWebElement TermsCheckBox => Driver.FindElement(By.XPath("//*[@class='vivacom-icon icon-box_empty']"));

        public IWebElement ContinueAsClientDisabledButton => Driver.FindElement(By.XPath("//*[@class='btn btn-success js-checkout-btn disable-elm']"));

        public IWebElement ContinueAsClientButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Продължи като клиент']"));

        public IWebElement ContinueAsGuestDisabledButton => Driver.FindElement(By.XPath("//*[@class='btn btn-success js-support-checkout-btn disable-elm']"));

        public IWebElement ContinueAsGuestButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Продължи като гост']"));

        public IWebElement EmptyShoppingCardMessage => Driver.FindElement(By.ClassName("empty-shopping-cart"));

        public void ShoppingCardPageIsLoaded(string expectedResult, string actualResult)
        {
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
