namespace api.Models;

public record RegisterUser(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string Email,
    string UserName,
    string Password,
    int Age
    );