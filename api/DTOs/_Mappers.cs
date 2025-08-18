namespace api.DTOs;

public static class Mappers
{
    public static AppUser ConvertRegisterDtoToAppUser(RegisterDto registerDto)
    {
        return new AppUser(
            Email: registerDto.Email,
            UserName: registerDto.UserName,
            Password: registerDto.Password,
            ConfirmPassword: registerDto.ConfirmPassword,
            DateOfBirth: registerDto.DateOfBirth,
            City: "",
            Country: "",
            Photos: new List<Photo>()
        );
    }

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