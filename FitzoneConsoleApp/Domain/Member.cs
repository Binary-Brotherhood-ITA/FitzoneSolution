using MongoDB.Bson.Serialization.Attributes;

namespace FitzoneConsoleApp.Domain;

public class Member
{
    // Medlemmets ID i MongoDB
    [BsonId]
    public string MemberNo { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MembershipStatus { get; set; } = string.Empty;
}