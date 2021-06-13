using OpenQA.Selenium;
using VivacomQAAutomationTask.Base;

namespace VivacomQAAutomationTask.Pages
{
    public class SpecificAccessoryPage : BasePage
    {
        public SpecificAccessoryPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => ("https://www.vivacom.bg/online/bg/shop/devices/product-category-accessories/apple-%D1%81%D0%BB%D1%83%D1%88%D0%B0%D0%BB%D0%BA%D0%B8-%D1%81-lightning-connector?offer=epc_simfreedevice00000001_so_xdw210531180652081376");

        public IWebElement AccessoryTitle => Driver.FindElement(By.ClassName("favourites-device-main-title"));

        public IWebElement AccessoryBuyButton => Driver.FindElement(By.XPath("//*[@id='command']//*[@class='vivacom-icon icon-shopping_cart']"));
    }
}
