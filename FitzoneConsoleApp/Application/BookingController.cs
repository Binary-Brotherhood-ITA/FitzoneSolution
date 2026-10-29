using FitzoneConsoleApp.DataAccessLayer;
using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.Application;

public class BookingController
{
    // Referencer til vores repositories
    private BookingRepository br = new BookingRepository();
    private MemberRepository mr = new MemberRepository();
    private FitnessClassRepository fc = new FitnessClassRepository();

    // Gemmer en fejlbesked, hvis bookingen ikke kan gennemføres
    public string ErrorMessage = "";

    public Booking? BookClass(string memberNo, string classId)   
    {
        ErrorMessage = "";

        // Finder medlemmet ud fra medlemsnummer
        // (C#'s nullable reference type "?": betyder i  dette tilfælde Member-objekt eller være null)
        Member? member = mr.GetByMemberNo(memberNo);

        if (member == null)
        {
            ErrorMessage = "Ukendt medlemsnummer";
            return null;
        }

        // Kontrollerer om medlemskabet er aktivt
        if (member.MembershipStatus != "Active")
        {
            ErrorMessage = "Dit medlemskab er ikke aktivt";
            return null;
        }

        // Finder fitnessholdet ud fra ID
        FitnessClass? fitnessClass = fc.GetById(classId);

        if (fitnessClass == null)
        {
            ErrorMessage = "Fitnessholdet findes ikke";
            return null;
        }

        // Kontrollerer om fitnessholdet er startet
        if (fitnessClass.StartTime <= DateTime.UtcNow)
        {
            ErrorMessage = "Fitnessholdet er allerede startet";
            return null;
        }

        // Kontrollerer om fitnessholdet er fyldt
        int count = br.CountByClassId(classId);

        if (count >= fitnessClass.Capacity)
        {
            ErrorMessage = "Fitnessholdet er fyldt";
            return null;
        }

        // Kontrollerer om medlemmet allerede er booket
        bool booked = br.Exists(memberNo, classId);

        if (booked == true)
        {
            ErrorMessage = "Du er allerede booket på dette hold";
            return null;
        }

        // Opretter en ny booking
        Booking booking = new Booking();

        // String "-" sørger for at bookingId bliver lavet ved at tage memberNo og classId og have en bindestreg imellem. Lille fed funktion. 
        booking.BookingId = memberNo + "-" + classId;
        booking.MemberNo = memberNo;
        booking.ClassId = classId;
        booking.BookedAt = DateTime.UtcNow;

        // Gemmer bookingen i databasen
        br.Add(booking);

        return booking;
    }

    // Henter alle kommende fitnesshold
    public List<FitnessClass> GetUpcomingClasses()
    {
        return fc.GetUpcoming(DateTime.UtcNow);
    }
}
