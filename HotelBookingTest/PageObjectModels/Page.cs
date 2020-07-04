using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HotelBookingTest.PageObjectModels
{
    class Page
    {
        protected IWebDriver Driver;

        protected WebDriverWait ExplicitWait;
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        /// <summary>
        /// Checks that the URL and page title are as expected
        /// </summary>
        /// <param name="onlyCheckUrlStartsWithExpectedText">Set to false to do an exact match of URL. Set to true to ignore fragments, query string, etc at end of browser URL</param>
        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;

            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(PageUrl);
            }
            else
            {
                urlIsCorrect = Driver.Url == PageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == PageTitle);


            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
    }
}
