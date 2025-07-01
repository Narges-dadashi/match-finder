namespace api.DTOs;

public static class Mappers
{
    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName
        );
    }

    public static MemberDto ConvertAppUserToMemberDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName,
            Age: appUser.Age,
            City: appUser.City,
            Country: appUser.Country
        );
    }
}