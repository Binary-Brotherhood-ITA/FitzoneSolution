using FitzoneConsoleApp.Domain;
using FitzoneConsoleApp.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FitzoneConsoleApp.DataAccessLayer;

public class MemberRepository : IMemberRepository
{
    // Reference til members collection i MongoDB
    private readonly IMongoCollection<Member> _members;
    // Constructoren opretter forbindelsen til databasen
    public MemberRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        // Connection string til MongoDB
        string databaseName = configuration["MongoDb:DatabaseName"] ?? "FitzoneDB";

        // Vælger databasen FitzoneDB
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);

        // Henter members collection fra MongoDB
        _members = database.GetCollection<Member>("members");
    }

    // Finder et medlem ud fra medlemsnummer
    // FirstOrDefault(): Returner først fundne resultat, ellers returner null
    public Member? GetByMemberNo(string memberNo)
    {
        return _members
            .Find(m => m.MemberNo == memberNo)
            .FirstOrDefault();
    }
}