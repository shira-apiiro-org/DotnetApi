using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotnetApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public DateOnly DateOfBirth { get; set; }

    public int Age { get; set; }
}
