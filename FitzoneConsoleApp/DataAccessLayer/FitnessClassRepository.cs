using MongoDB.Driver;
using FitzoneConsoleApp.Domain;

namespace FitzoneConsoleApp.DataAccessLayer;

public class FitnessClassRepository
{
    // Reference til fitnessClasses collection fra mongodb
    private readonly IMongoCollection<FitnessClass> _fitnessClasses;

    // Constructoren opretter forbindelsen til databasen
    public FitnessClassRepository()
    {
        // Connection string til MongoDB ______ HUSK DETTE ER MIN (FAWSI) CONNECTIONSTRING. SKIFT DEN TIL JERES EGEN
        string connectionString = "mongodb+srv://fowcode101_db_user:HwwDv43fWKoUb1Jl@cluster0.7xn4frh.mongodb.net/";

        MongoClient client = new MongoClient(connectionString);

        // Vælger databasen FitzoneDB
        IMongoDatabase database = client.GetDatabase("FitzoneDB");

        // Henter fitnessClasses collection fra MongoDB
        _fitnessClasses =
            database.GetCollection<FitnessClass>("fitnessClasses");
    }

    // Henter alle kommende fitnesshold
    public List<FitnessClass> GetUpcoming(DateTime now)
    {
        return _fitnessClasses
            .Find(fc => fc.StartTime > now)
            .SortBy(fc => fc.StartTime)
            .ToList();
    }

    //Finder et fitnesshold ud fra dets ID
    // ? tillader at FitnessClass må være null
    // FirstOrDefault(): Returner først fundne resultat ellers returner null
    // => er lambda. Det er en funktion der siger i fc skal du finde det ClassId der er lig emd classId
    public FitnessClass? GetById(string classId)
    {
        return _fitnessClasses.Find(fc => fc.ClassId == classId).FirstOrDefault();
    }

    public FitnessClass? getSelectedClass(string classId)
    {
        return _fitnessClasses.Find(fc => fc.ClassId == classId).FirstOrDefault();
    }

}

