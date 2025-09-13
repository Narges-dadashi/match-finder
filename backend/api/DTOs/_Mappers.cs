namespace api.DTOs;

public static class Mappers
{
    public static AppUser ConvertRegisterDtoToAppUser(RegisterDto registerDto)
    {
        return new AppUser(
            Id: null,
            Email: registerDto.Email,
            UserName: registerDto.UserName,
            Password: registerDto.Password,
            ConfirmPassword: registerDto.ConfirmPassword,
            DateOfBirth: registerDto.DateOfBirth,
            City: "",
            Country: "",
            Photos: []
        );
    }

    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser, string tokenValue)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName,
            Age: Extensions.DateTimeExtensions.CalculateAge(appUser.DateOfBirth),
            Token: tokenValue
        );
    }

    public static MemberDto ConvertAppUserToMemberDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName,
            Age: Extensions.DateTimeExtensions.CalculateAge(appUser.DateOfBirth),
            City: appUser.City,
            Country: appUser.Country
        );
    }

    public static UpdateDto ConvertRegisterDtoToUpdateDto(RegisterDto registerDto)
    {
        return new(
            Email: registerDto.Email
        );
    }

    public static Photo ConvertPhotoUrlsToPhoto(string[] photoUrls, bool isMain)
    {
        return new Photo(
            Url_165: photoUrls[0],
            Url_256: photoUrls[1],
            Url_enlarged: photoUrls[2],
            IsMain: isMain
        );
    }
}