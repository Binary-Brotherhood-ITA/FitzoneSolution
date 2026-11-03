using FitzoneConsoleApp.Interfaces;
using MongoDB.Driver;
using FitzoneConsoleApp.Domain;
using Microsoft.Extensions.Configuration;

namespace FitzoneConsoleApp.DataAccessLayer;

public class BookingRepository : IBookingRepository
{
    // Reference til bookings collection i MongoDB
    private readonly IMongoCollection<Booking> _bookings;

    // Constructoren opretter forbindelsen til databasen
    public BookingRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        // Connection string til MongoDB
        string databaseName = configuration["MongoDb:DatabaseName"] ?? "FitzoneDB";

        // Vælger databasen FitzoneDB
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);

        // Henter bookings collection MongoDB
        _bookings = database.GetCollection<Booking>("bookings");
    }

    // Tæller hvor mange bookinger der findes på et bestemt hold
    //CountDocuments returnerer en long-type. Den konverterer vi til int.
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