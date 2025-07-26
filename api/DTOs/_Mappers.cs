using api.Extensions;

namespace api.DTOs;

public static class Mappers
{
    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser, string tokenValue)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName,
            Token: tokenValue
        );
    }

    public static MemberDto ConvertAppUserToMemberDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName,
            Age: DateTimeExtensions.CalculateAge(appUser.DateOfBirth),
            City: appUser.City,
            Country: appUser.Country
        );
    }
}