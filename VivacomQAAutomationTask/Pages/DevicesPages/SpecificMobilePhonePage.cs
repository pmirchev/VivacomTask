using OpenQA.Selenium;
using System.Collections.ObjectModel;
using VivacomQAAutomationTask.Base;

namespace VivacomQAAutomationTask.Pages
{
    public class SpecificMobilePhonePage : BasePage
    {
        public SpecificMobilePhonePage(IWebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => ("https://www.vivacom.bg/online/bg/shop/devices/product-category-smart-mobile-phones/apple-iphone-12-pro-max-128gb?offer=epc_ouv210528140047400573_so_qcq210531150154728692");

        public IWebElement PhoneTitle => Driver.FindElement(By.ClassName("favourites-device-main-title"));

        public IWebElement NewServiceButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Нова услуга']"));

        public IWebElement OneTimePaymentButton => Driver.FindElement(By.XPath("//*[@id='relatedOfferDiv-epc_jjl210528140034250049_so_jyx210531150154654235']//*[@class='e-care-home-big-bill-price-digits js-related-offer-cash-price-span']"));

        public IWebElement PhoneBuyButton => Driver.FindElement(By.XPath("//*[@id='command']//*[@class='vivacom-icon icon-shopping_cart']"));
    }
}
