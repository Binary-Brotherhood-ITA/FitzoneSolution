using MongoDB.Bson.Serialization.Attributes;

namespace FitzoneConsoleApp.Domain;

public class FitnessClass
{
    // Fitnessholdets ID i MongoDB
    [BsonId]
    public string ClassId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Instructor { get; set; } = string.Empty;

    public string Room { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public int DurationMinutes { get; set; }

    public int Capacity { get; set; }
}