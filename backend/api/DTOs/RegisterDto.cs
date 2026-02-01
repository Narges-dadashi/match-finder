namespace api.DTOs;

public record RegisterDto(
    [EmailAddress]
    string Email,
    string UserName,
    DateOnly DateOfBirth,
    string Password,
    string ConfirmPassword,
    [Length(3, 20)] string Gender
);