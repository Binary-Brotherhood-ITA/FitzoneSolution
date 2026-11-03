using FitzoneConsoleApp.Interfaces;
using MongoDB.Driver;
using FitzoneConsoleApp.Domain;
using Microsoft.Extensions.Configuration;

namespace FitzoneConsoleApp.DataAccessLayer;

public class FitnessClassRepository : IFitnessClassRepository
{
    // Reference til fitnessClasses collection fra mongodb
    private readonly IMongoCollection<FitnessClass> _fitnessClasses;

    // Constructoren opretter forbindelsen til databasen
    public FitnessClassRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        // Connection string til MongoDB
        string databaseName = configuration["MongoDb:DatabaseName"] ?? "FitzoneDB";

        // Vælger databasen FitzoneDB
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);

        // Henter fitnessClasses collection fra MongoDB
        _fitnessClasses = database.GetCollection<FitnessClass>("fitnessClasses");
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

