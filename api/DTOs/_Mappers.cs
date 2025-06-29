namespace api.DTOs;

public static class _Mappers
{
    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName
        );
    }
}