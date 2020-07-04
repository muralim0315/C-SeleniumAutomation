using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using HotelBookingTest.Utility;
using OpenQA.Selenium.Interactions;

namespace HotelBookingTest.PageObjectModels
{
    class HomePage:Page
    {
      public HomePage(IWebDriver driver)
        {
            Driver = driver;
            ExplicitWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected override string PageUrl => "http://hotel-test.equalexperts.io/";
        protected override string PageTitle => "Hotel booking form";


        IWebElement txtfristName => Driver.FindElement(By.Id("firstname"));
        IWebElement txtlastName => Driver.FindElement(By.Id("lastname"));
        IWebElement txttotalprice => Driver.FindElement(By.Id("totalprice"));
        IWebElement drpDeposit => Driver.FindElement(By.Id("depositpaid"));
        IWebElement divBookings => Driver.FindElement(By.Id("bookings"));

        ReadOnlyCollection<IWebElement> RowsToDelete => Driver.FindElements(By.XPath("//input[@type='button' and @value='Delete']"));
        ReadOnlyCollection<IWebElement> TotalBookings => Driver.FindElements(By.XPath("//div[@id='bookings']/div"));
        IWebElement btnSave => Driver.FindElement(By.XPath("//input[@type='button' and @value=' Save ']"));

        public void EnterfristName(string fname)
        {
            txtfristName.Clear();
            txtfristName.SendKeys(fname);
        }

        public void EnterLastName(string lastName)
        {
            txtlastName.Clear();
            txtlastName.SendKeys(lastName);
        }

        public void EnterPrice(string price)
        {
            txttotalprice.Clear();
            txttotalprice.SendKeys(price);
        }

        public void ClickSave(int existingBookings)
        {
           SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(btnSave);

            btnSave.Click();
            ExplicitWait.Until(wd => Utilities.WaitForNewbookingAppears(existingBookings,Driver));
        }

      
        public void EnterCheckInDate(DateTime checkIn)
        {
            int day = checkIn.Date.Day;
            Driver.FindElement(By.Id("checkin")).Click();
            string DateXpath = @"//a[text()='"+ day.ToString()+"']";
            Driver.FindElement(By.XPath(DateXpath)).Click();
        }

        public void EnterCheckOutDate(DateTime checkOut)
        {
            int day = checkOut.Date.Day;
            Driver.FindElement(By.Id("checkout")).Click();
            string DateXpath = @"//a[text()='" + day.ToString() + "']";
            Driver.FindElement(By.XPath(DateXpath)).Click();
        }
        public void ChooseDeposit(bool isDepoistRequired)
        {            
            SelectElement businessSource = new SelectElement(drpDeposit);
            if(isDepoistRequired)
            businessSource.SelectByText("true");
            else
            businessSource.SelectByText("false");
        }
        public void ClickDeleteButon()
        {
           
            foreach (IWebElement deleteItem in RowsToDelete)
            {
                ExplicitWait.Until(Dr => SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(deleteItem));
                deleteItem.Click();
            }

        }        
       

      

        public int GetTotalLatestBookings()
        {
            ExplicitWait.Until(wd => Utilities.WaitForPageFullyloaded(10000,150,Driver) == true);    
            return TotalBookings.Count-1;
        }
             


    }
}
