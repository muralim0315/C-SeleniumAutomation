using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace HotelBookingTest.Utility
{
    public static class Utilities
    {       
       internal static bool WaitForNewbookingAppears(int previousBookings, IWebDriver Driver)
        {
            ReadOnlyCollection<IWebElement> totalBookingsLatest = Driver.FindElements(By.XPath("//div[@id='bookings']/div"));
            if (totalBookingsLatest.Count > previousBookings)
                return true;
            else
                return false;
        }

        internal static bool WaitForPageFullyloaded(int maxWait, int pollingTime, IWebDriver driver)
        {
            DateTime maxWaiTime = DateTime.Now.AddMilliseconds(maxWait);
            string pageSource = driver.PageSource;
              while(DateTime.Now<maxWaiTime)
            {
                if (pageSource.Equals(driver.PageSource))
                    return true;               
                    Thread.Sleep(pollingTime); 
            }

            return false;


        }
    }
}
