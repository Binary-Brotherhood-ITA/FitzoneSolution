using MongoDB.Bson.Serialization.Attributes;

namespace FitzoneConsoleApp.Domain;

public class Member
{
    [BsonId]
    public string memberNo { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string membershipStatus { get; set; }
}