using OpenQA.Selenium;

namespace VivacomQAAutomationTask.Utilities
{
    public static class Extensions
    {
        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
