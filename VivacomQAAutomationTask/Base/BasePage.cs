using OpenQA.Selenium;
using System;

namespace VivacomQAAutomationTask.Base
{
    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public IWebDriver Driver { get; private set; }

        public abstract string Url { get; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
