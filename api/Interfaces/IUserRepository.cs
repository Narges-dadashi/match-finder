namespace api.Interfaces;

public interface IUserRepository
{
    public Task<List<AppUser>?> GetAllAsync(CancellationToken cancellationToken);
    public Task<UpdateDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken);
}