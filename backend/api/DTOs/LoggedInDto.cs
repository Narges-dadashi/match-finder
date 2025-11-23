namespace api.DTOs;

public class LoggedInDto
{
    public string? Token { get; init; }
    public string? Email { get; init; }
    public string? UserName { get; init; }
    public int? Age { get; init; }
    public bool IsWrongCreds { get; set; }
    public List<string> Errors { get; set; } = [];
    public string? ProfilePhotoUrl { get; init; }
}