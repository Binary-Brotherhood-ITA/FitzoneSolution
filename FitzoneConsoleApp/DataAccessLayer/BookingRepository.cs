using FitzoneConsoleApp.Domain;
using MongoDB.Driver;

namespace FitzoneConsoleApp.DataAccessLayer;

public class BookingRepository
{
    // Reference til DB her!! 
    public BookingRepository()
    {
    }

    public int countByClassId(string classId)
        {
            // Insert code here


            return 0;
        }

        public bool exists(string memberNo, string classId)
        {
            //Insert code here

            return true;
        }

        public void add(Booking b)
        {
            //insert code here
            
        }
}