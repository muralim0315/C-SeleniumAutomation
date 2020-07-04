using System;
using HotelBookingTest.Helper;
using HotelBookingTest.PageObjectModels;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace HotelBookingTest
{
    class HotelBookingTests
    {
        private  DriverFixture _driverFixture;
    
        [SetUp]
        public void BeforeScenario()
        {
            _driverFixture = new DriverFixture("Chrome");
            _driverFixture.Driver.Manage().Cookies.DeleteAllCookies();
            _driverFixture.Driver.Manage().Window.Maximize();
            _driverFixture.Driver.Navigate().GoToUrl("about:blank");
        }

        [TearDown]
        public void AfterScenario()
        {
            _driverFixture.Dispose();          
        }

        [Test]
        public void CreateBooking()
        {
            int existingBookings = 0;
            var homePage = new HomePage(_driverFixture.Driver);
            homePage.NavigateTo();
            existingBookings = homePage.GetTotalLatestBookings();
            DemoHelper.Pause();
            homePage.EnterfristName("Scott");
            DemoHelper.Pause();
            homePage.EnterLastName("Andrew");
            DemoHelper.Pause();
            homePage.EnterPrice("150");
            DemoHelper.Pause();
            homePage.ChooseDeposit(false);
            DemoHelper.Pause();
            homePage.EnterCheckInDate(DateTime.Now);
            DemoHelper.Pause();
            homePage.EnterCheckOutDate(DateTime.Now.AddDays(2));
            DemoHelper.Pause();
            homePage.ClickSave(existingBookings);
            DemoHelper.Pause(10000);
            Assert.AreEqual(homePage.GetTotalLatestBookings() - 1, existingBookings);
           
        }
        [Test]
        public void DeleteBooking ()
        {
            int existingBookings;
            var homePage = new HomePage(_driverFixture.Driver);
            homePage.NavigateTo();
            existingBookings = homePage.GetTotalLatestBookings();
            DemoHelper.Pause(5000);
            homePage.ClickDeleteButon();
            DemoHelper.Pause(6000);
            if (existingBookings == 0)
                TestContext.WriteLine("There were no bookings to Delete");
            else
            Assert.Less(homePage.GetTotalLatestBookings(), existingBookings);

        }
    }
}
