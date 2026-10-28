using MongoDB.Driver;
using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.DataAccessLayer;

public class BookingRepository
{
    // Reference til bookings collection i MongoDB
    private readonly IMongoCollection<Booking> _bookings;

    // Constructoren opretter forbindelsen til databasen
    public BookingRepository()
    {
        // Connection string til MongoDB ______ HUSK DETTE ER MIN (FAWSI) CONNECTIONSTRING. SKIFT DEN TIL JERES EGEN
        string connectionString = "mongodb+srv://fowcode101_db_user:HwwDv43fWKoUb1Jl@cluster0.7xn4frh.mongodb.net/";

        MongoClient client = new MongoClient(connectionString);

        // Vælger databasen FitzoneDB
        IMongoDatabase database = client.GetDatabase("FitzoneDB");

        // Henter bookings collection MongoDB
        _bookings = database.GetCollection<Booking>("bookings");
    }

    // Tæller hvor mange bookinger der findes på et bestemt hold
    public int CountByClassId(string classId)
    {
        long count = _bookings.CountDocuments(
            b => b.ClassId == classId);

        return (int)count;
    }

    // Kontrollerer om et medlem allerede har booket holdet
    public bool Exists(string memberNo, string classId)
    {
        Booking? booking = _bookings
            .Find(b => b.MemberNo == memberNo &&
                       b.ClassId == classId)
            .FirstOrDefault();

        return booking != null;
    }

    // Gemmer en ny booking i vores MongoDB
    public void Add(Booking b)
    {
        _bookings.InsertOne(b);
    }
}