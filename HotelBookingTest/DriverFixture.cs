using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace HotelBookingTest
{
    public class DriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public DriverFixture(string browserType)
        {
            //Driver = new ChromeDriver();
            switch (browserType)
            {
                case "InternetExplorer":
                    Driver = new InternetExplorerDriver();
                    break;
                case "FireFox":
                    Driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;
            }
        }

        public void Dispose()
        {
            Driver.Dispose();
        }


    }

    
}
