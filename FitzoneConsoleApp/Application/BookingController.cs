using System.Diagnostics.CodeAnalysis;
using FitzoneConsoleApp.DataAccessLayer;
using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.Application;


public class BookingController
{
    private BookingRepository br = new BookingRepository();
    private MemberRepository mr = new MemberRepository();
    private FitnessClassRepository fc = new FitnessClassRepository();
    public BookingController()
    {
        
    }

    public Booking BookClass(int memberNo, int classId)
    {
       // insert code
        
        return null;
    } 
    
    public List<FitnessClass>  GetUpcomingClasses()
    {
        // insert code
        
        
        return null;
    }
    
    
}