namespace api.Models;

public record AppUser(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    [EmailAddress] string Email,
    string UserName,
    string Password,
    string ConfirmPassword,
    int Age,
    string City,
    string Country
    );