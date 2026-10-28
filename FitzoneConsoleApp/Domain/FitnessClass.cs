using MongoDB.Bson.Serialization.Attributes;
namespace FitzoneConsoleApp.Domain;

public class FitnessClass
{
    [BsonId]
    public string classId { get; set; }

    public string title { get; set; }

    public string instructor { get; set; }

    public string room { get; set; }

    public DateTime startTime { get; set; }

    public int durationMinutes { get; set; }

    public int capacity { get; set; }
}