using NUnit.Framework;
using OpenQA.Selenium;
using VivacomQAAutomationTask.Base;
using VivacomQAAutomationTask.Pages;
using VivacomQAAutomationTask.Utilities;

namespace VivacomQAAutomationTask.Tests
{
    [TestFixture]
    public class Navigation : BaseTest
    {
        private const string ExpectedPhoneTitle = "APPLE IPHONE 12 PRO MAX 128GB";
        private const string ExpectedAccessoryTitle = "APPLE СЛУШАЛКИ с LIGHTNING CONNECTOR";

        private HomePage _homePage;
        private MobilePhonesPage _mobilePhonesPage;
        private AccessoriesPage _accessoriesPage;
        private SpecificMobilePhonePage _specificMobilePhonePage;
        private SpecificAccessoryPage _specificAccessoryPage;

        private IWebElement DevicesMenu => Driver.FindElement(By.XPath("//*[@id='menu-slider']"));

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _homePage = new HomePage(Driver);
            _mobilePhonesPage = new MobilePhonesPage(Driver);
            _specificMobilePhonePage = new SpecificMobilePhonePage(Driver);
            _accessoriesPage = new AccessoriesPage(Driver);
            _specificAccessoryPage = new SpecificAccessoryPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            //Screenshot();
            Driver.Quit();
        }

        [Test]
        public void CorrectPageIsLoaded_When_NavigateToDevicesPage()
        {
            _homePage.NavigateTo();

            _homePage.DevicesButton.Click();
            _homePage.MobilePhonesButton.Click();

            Assert.IsTrue(DevicesMenu.Displayed);
        }

        [Test]
        public void CorrectPageIsLoaded_When_NavigateToAccessoriesPage()
        {
            _homePage.NavigateTo();

            _homePage.DevicesButton.Click();
            _homePage.AccessoriesButton.Click();

            Assert.IsTrue(DevicesMenu.Displayed);
        }

        [Test]
        public void CorrectPageIsLoaded_When_NavigateToDesiredMobilePhone()
        {
            _mobilePhonesPage.NavigateTo();

            _mobilePhonesPage.PhoneBrandFilterButton.Click();
            Extensions.ScrollTo(Driver, _mobilePhonesPage.PhoneColorFilterSection);
            _mobilePhonesPage.PhoneColorFilterButton.Click();
            Extensions.ScrollTo(Driver, DevicesMenu);
            _mobilePhonesPage.DesiredDeviceButton.Click();

            Assert.AreEqual(ExpectedPhoneTitle, _specificMobilePhonePage.PhoneTitle.Text);
        }

        [Test]
        public void CorrectPageIsLoaded_When_NavigateToDesiredAccessory()
        {
            _accessoriesPage.NavigateTo();

            _accessoriesPage.AccessoriesBrandFilterButton.Click();
            Extensions.ScrollTo(Driver, _accessoriesPage.AccessoriesPriceFilterSection);
            _accessoriesPage.AccessoriesPriceFilterButton.Click();
            Extensions.ScrollTo(Driver, DevicesMenu);
            _accessoriesPage.DesiredAccessoryButton.Click();

            Assert.AreEqual(ExpectedAccessoryTitle, _specificAccessoryPage.AccessoryTitle.Text);
        }
    }
}
