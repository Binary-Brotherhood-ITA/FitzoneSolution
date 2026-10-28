using MongoDB.Bson.Serialization.Attributes;
namespace FitzoneConsoleApp.Domain;

public class Booking
{
    [BsonId]
    public string bookingId { get; set; }
    public string memberNo { get; set; }
    public string classId { get; set; }
    public DateTime bookedAt { get; set; }
    
}