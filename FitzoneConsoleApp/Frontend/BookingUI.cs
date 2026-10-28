using FitzoneConsoleApp.Application;
using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.Frontend;

public class BookingUI
{
    // Reference til vores controller
    private BookingController controller = new BookingController();

    // Starter programmets menu
    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== FITZONE BOOKING =====");
            Console.WriteLine("1. Vis kommende hold og book");
            Console.WriteLine("0. Afslut");
            Console.Write("Vælg en mulighed: ");

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                ShowUpcomingClasses();
            }
            else if (choice == "0")
            {
                running = false;
                Console.WriteLine("Programmet afsluttes.");
            }
            else
            {
                Console.WriteLine("Ugyldigt valg.");
            }
        }
    }

    // Viser alle kommende fitnesshold
    public void ShowUpcomingClasses()
    {
        // Henter fitnesshold fra controlleren
        List<FitnessClass> classes = controller.GetUpcomingClasses();

        Console.WriteLine("\n===== KOMMENDE HOLD =====");

        if (classes.Count == 0)
        {
            Console.WriteLine("Ingen kommende hold fundet.");
            return;
        }

        // Viser information om hvert fitnesshold
        foreach (FitnessClass fc in classes)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"ID: {fc.ClassId}");
            Console.WriteLine($"Titel: {fc.Title}");
            Console.WriteLine($"Instruktør: {fc.Instructor}");
            Console.WriteLine($"Start: {fc.StartTime.ToLocalTime()}");
            Console.WriteLine($"Kapacitet: {fc.Capacity}");
        }

        // Brugeren indtaster oplysninger til booking
        Console.WriteLine("\n===== BOOK ET HOLD =====");

        Console.Write("Indtast medlemsnummer: ");
        string memberNo = Console.ReadLine() ?? "";

        Console.Write("Indtast holdets ID: ");
        string classId = Console.ReadLine() ?? "";

        // Sender oplysningerne til controlleren
        Booking? booking = controller.BookClass(memberNo, classId);

        if (booking == null)
        {
            // Viser fejlbeskeden fra controlleren
            Console.WriteLine("\nBooking mislykkedes!");
            Console.WriteLine(controller.ErrorMessage);
        }
        else
        {
            // Finder holdet, så vi kan vise en bekræftelse
            FitnessClass? selectedClass =
                classes.Find(fc => fc.ClassId == classId);

            Console.WriteLine("\nBooking gennemført!");

            if (selectedClass != null)
            {
                Console.WriteLine($"Hold: {selectedClass.Title}");
                Console.WriteLine($"Start: {selectedClass.StartTime.ToLocalTime()}");
            }

            Console.WriteLine($"Medlemsnummer: {booking.MemberNo}");
            Console.WriteLine($"Booket: {booking.BookedAt.ToLocalTime()}");
        }
    }
}
