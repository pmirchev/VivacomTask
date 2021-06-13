using OpenQA.Selenium;
using VivacomQAAutomationTask.Base;

namespace VivacomQAAutomationTask.Pages
{
    public class MobilePhonesPage : BasePage
    {
        public MobilePhonesPage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => ("https://www.vivacom.bg/online/bg/shop/devices/listing?navigation=product-category-smart-mobile-phones");

        public IWebElement PhoneBrandFilterButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='APPLE']"));

        public IWebElement PhoneColorFilterSection => Driver.FindElement(By.XPath("//*[normalize-space(text())='Цвят']"));

        public IWebElement PhoneColorFilterButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='GOLD']"));

        public IWebElement DesiredDeviceButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='APPLE IPHONE 12 PRO MAX 128GB']"));
    }
}
