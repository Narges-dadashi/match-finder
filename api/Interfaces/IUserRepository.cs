namespace api.Interfaces;

public interface IUserRepository
{
    public Task<MemberDto?> UpdateByIdAsync(AppUser userInput, CancellationToken cancellationToken);
}