namespace api.Models;

[CollectionName("users")]
public class AppUser : MongoIdentityUser<ObjectId>
{
    [Range(typeof(DateOnly), "1900-01-01", "2050-01-01",
        ErrorMessage = "Date of birth must be between 1900 and 2050.")]
    public DateOnly DateOfBirth { get; init; }
    public DateTime LastActive { get; init; }
    public string Gender { get; init; } = string.Empty;
    public string Introduction { get; init; } = string.Empty;
    public string LookingFor { get; init; } = string.Empty;
    public string Interests { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public List<Photo> Photos { get; init; } = [];
}