using MongoDB.Bson.Serialization.Attributes;

namespace FitzoneConsoleApp.Domain;

public class Member
{
    // Medlemmets ID i MongoDB
    [BsonId]
    public string MemberNo { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string MembershipStatus { get; set; }
}