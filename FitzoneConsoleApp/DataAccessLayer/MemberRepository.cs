using MongoDB.Driver;
using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.DataAccessLayer;

public class MemberRepository
{
    // Reference til members collection i MongoDB
    private readonly IMongoCollection<Member> _members;

    // Constructoren opretter forbindelsen til databasen
    public MemberRepository()
    {
        // Connection string til MongoDB ______ HUSK DETTE ER MIN (FAWSI) CONNECTIONSTRING. SKIFT DEN TIL JERES EGEN
        string connectionString = "mongodb+srv://fowcode101_db_user:HwwDv43fWKoUb1Jl@cluster0.7xn4frh.mongodb.net/";

        MongoClient client = new MongoClient(connectionString);

        // Vælger databasen FitzoneDB
        IMongoDatabase database = client.GetDatabase("FitzoneDB");

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