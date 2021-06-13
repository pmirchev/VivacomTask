using OpenQA.Selenium;
using VivacomQAAutomationTask.Base;

namespace VivacomQAAutomationTask.Pages
{
    class AccessoriesPage : BasePage
    {
        public AccessoriesPage(IWebDriver driver)
            : base(driver)
        {
        }

        public override string Url => ("https://www.vivacom.bg/online/bg/shop/devices/listing?navigation=product-category-accessories");

        public IWebElement AccessoriesBrandFilterButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='APPLE']"));

        public IWebElement AccessoriesPriceFilterSection => Driver.FindElement(By.XPath("//*[normalize-space(text())='Цена']"));

        public IWebElement AccessoriesPriceFilterButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='между 5 и 40 лв.']"));

        public IWebElement DesiredAccessoryButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='APPLE СЛУШАЛКИ с LIGHTNING CONNECTOR']"));
    }
}
