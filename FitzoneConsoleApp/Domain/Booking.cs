using MongoDB.Bson.Serialization.Attributes;

namespace FitzoneConsoleApp.Domain;

public class Booking
{
    // Bookingens unikke ID i MongoDB
    [BsonId]
    public string BookingId { get; set; } = string.Empty;

    public string MemberNo { get; set; } = string.Empty;

    public string ClassId { get; set; } = string.Empty;

    public DateTime BookedAt { get; set; }
}