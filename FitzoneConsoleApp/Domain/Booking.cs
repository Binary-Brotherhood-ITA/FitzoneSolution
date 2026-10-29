using MongoDB.Bson.Serialization.Attributes;

namespace FitzoneConsoleApp.Domain;

public class Booking
{
    // Bookingens unikke ID i MongoDB
    [BsonId]
    public string BookingId { get; set; }

    public string MemberNo { get; set; }

    public string ClassId { get; set; }

    public DateTime BookedAt { get; set; }
}