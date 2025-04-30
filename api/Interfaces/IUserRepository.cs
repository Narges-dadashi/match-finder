namespace api.Interfaces;

public interface IUserRepository
{
    public Task<UpdateDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken);
}