namespace api.Models;

public record AppUser(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    [EmailAddress] string Email,
    string UserName,
    string Password,
    string ConfirmPassword,
    [Range(typeof(DateOnly), "1900-01-01", "2050-01-01", ErrorMessage = "Date of birth must be between 1900 and 2050.")]
    DateOnly DateOfBirth,
    string City,
    string Country
    );