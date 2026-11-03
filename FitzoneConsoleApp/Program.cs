using FitzoneConsoleApp.Interfaces;
using FitzoneConsoleApp.Frontend;
using FitzoneConsoleApp.Application;
using FitzoneConsoleApp.DataAccessLayer;

internal class Program
{
    private static void Main(string[] args)
    {
        
// Opretter vores BookingUI

        IBookingRepository br = new BookingRepository();
        IMemberRepository mr = new MemberRepository();
        IFitnessClassRepository fc = new FitnessClassRepository();

        BookingController bookingController =
            new BookingController(br, mr, fc);

        BookingUI ui = new BookingUI(bookingController);

// Starter bookingmenuen
        ui.Run();

    }
}