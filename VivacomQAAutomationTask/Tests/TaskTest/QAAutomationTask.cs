using NUnit.Framework;
using System;
using System.Linq;
using VivacomQAAutomationTask.Base;
using VivacomQAAutomationTask.Pages;
using VivacomQAAutomationTask.Utilities;

namespace VivacomQAAutomationTask.Tests
{
    [TestFixture]
    public class QAAutomationTask : BaseTest
    {
        private const string ShoppingCartPageTitle = "Моята кошница";
        private const double MaxPriceAvailable = 2000;

        private string ExpectedMessage = $"В момента кошницата ви е празна{Environment.NewLine}Вижте актуалните ни оферти и изберете най-подходящата за вас. Ако искате да разгледате предходно добавени продукти, натиснете \"Вход\".{Environment.NewLine}Вход";

        private SpecificMobilePhonePage _specificMobilePhonePage;
        private SpecificAccessoryPage _specificAccessoryPage;
        private ShoppingCardPage _shoppingCardPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _specificMobilePhonePage = new SpecificMobilePhonePage(Driver);
            _specificAccessoryPage = new SpecificAccessoryPage(Driver);
            _shoppingCardPage = new ShoppingCardPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Screenshot();
            Driver.Quit();
        }

        [Test]
        public void SuccessfulAddingProductsInBasket()
        {
            _specificMobilePhonePage.NavigateTo();
            Extensions.ScrollTo(Driver, _specificMobilePhonePage.NewServiceButton);

            _specificMobilePhonePage.OneTimePaymentButton.Click();
            _specificMobilePhonePage.PhoneBuyButton.Click();

            _shoppingCardPage.ShoppingCardPageIsLoaded(ShoppingCartPageTitle, _shoppingCardPage.PageTitle.Text);

            _specificAccessoryPage.NavigateTo();

            _specificAccessoryPage.AccessoryBuyButton.Click();

            _shoppingCardPage.ShoppingCardPageIsLoaded(ShoppingCartPageTitle, _shoppingCardPage.PageTitle.Text);

            string[] finalPriceAsString = _shoppingCardPage.FinalPrice.Text.Split().ToArray();
            double finalPrice = double.Parse(finalPriceAsString[0]);

            if (finalPrice > MaxPriceAvailable)
            {
                _shoppingCardPage.RemoveProductButtons[0].Click();
            }

            Assert.IsTrue(_shoppingCardPage.TermsCheckBox.Displayed);

            Extensions.ScrollTo(Driver, _shoppingCardPage.FinalPrice);
            var clientButtonColorBefore = _shoppingCardPage.ContinueAsClientDisabledButton.GetCssValue("background-color");
            var guestButtonColorBefore = _shoppingCardPage.ContinueAsGuestDisabledButton.GetCssValue("background-color");

            Assert.IsTrue(_shoppingCardPage.ContinueAsClientDisabledButton.Displayed);
            Assert.IsTrue(_shoppingCardPage.ContinueAsGuestDisabledButton.Displayed);

            _shoppingCardPage.TermsCheckBox.Click();
            var clientButtonColorAfter = _shoppingCardPage.ContinueAsClientButton.GetCssValue("background-color");
            var guestButtonColorAfter = _shoppingCardPage.ContinueAsGuestButton.GetCssValue("background-color");

            Assert.IsTrue(_shoppingCardPage.ContinueAsClientButton.Displayed);
            Assert.IsTrue(_shoppingCardPage.ContinueAsGuestButton.Displayed);
            Assert.AreNotEqual(clientButtonColorBefore, clientButtonColorAfter);
            Assert.AreNotEqual(guestButtonColorBefore, guestButtonColorAfter);

            Extensions.ScrollTo(Driver, _shoppingCardPage.PageTitle);

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(_shoppingCardPage.RemoveProductButtons[0]));   
            _shoppingCardPage.RemoveProductButtons[0].Click();

            Assert.IsTrue(_shoppingCardPage.EmptyShoppingCardMessage.Displayed);
            string actualMessage = _shoppingCardPage.EmptyShoppingCardMessage.Text.ToString();

            Assert.AreEqual(ExpectedMessage, actualMessage);
        }
    }
}
