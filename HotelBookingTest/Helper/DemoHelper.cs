using System.Threading;

namespace HotelBookingTest.Helper
{
    internal static class DemoHelper
    {
        ///// <summary>
        ///// Brief delay to slow down browser interactions for
        ///// demo video  purposes only
        ///// </summary>
        public static void Pause(int secondsToPause = 1000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}
