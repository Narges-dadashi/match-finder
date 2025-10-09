namespace api.DTOs;

public static class Mappers
{
    public static AppUser ConvertRegisterDtoToAppUser(RegisterDto registerDto)
    {
        return new AppUser(
            Id: null,
            Email: registerDto.Email.Trim().ToLower(),
            UserName: registerDto.UserName.Trim().ToLower(),
            Password: registerDto.Password,
            ConfirmPassword: registerDto.ConfirmPassword,
            DateOfBirth: registerDto.DateOfBirth,
            LastActive: DateTime.UtcNow,
            Introduction: string.Empty,
            LookingFor: string.Empty,
            Interests: string.Empty,
            Gender: string.Empty,
            City: string.Empty,
            Country: string.Empty,
            Photos: []
        );
    }

    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser, string tokenValue)
    {
        return new(
            Email: appUser.Email,
            UserName: appUser.UserName,
            Age: Extensions.DateTimeExtensions.CalculateAge(appUser.DateOfBirth),
            Token: tokenValue,
            ProfilePhotoUrl: appUser.Photos.FirstOrDefault(photo => photo.IsMain)?.Url_165
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