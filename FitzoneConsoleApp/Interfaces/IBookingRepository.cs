using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.Interfaces
{

    public interface IBookingRepository
    {
        int CountByClassId(string classId);

        bool Exists(string memberNo, string classId);

        void Add(Booking booking);
    }

}