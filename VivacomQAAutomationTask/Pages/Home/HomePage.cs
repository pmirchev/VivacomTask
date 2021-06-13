using OpenQA.Selenium;
using VivacomQAAutomationTask.Base;

namespace VivacomQAAutomationTask.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => ("https://www.vivacom.bg/bg/");

        public IWebElement DevicesButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Устройства']/parent::*[@class='dropdown']"));

        public IWebElement MobilePhonesButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Мобилни телефони']/parent::*[@class='dropdown-link-text']"));

        public IWebElement AccessoriesButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Аксесоари']/parent::*[@class='dropdown-link-text']"));
    }
}
