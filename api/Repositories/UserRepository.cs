namespace api.Repositories;

public class UserRepository : IUserRepository
{
    #region Db and Token Settings
    private readonly IMongoCollection<AppUser> _collection;

    // constructor - dependency injections
    public UserRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }
    #endregion

    public async Task<UpdateDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        UpdateDefinition<AppUser> updateDef = Builders<AppUser>.Update
        .Set(user => user.Email, userInput.Email.Trim().ToLower());

        await _collection.UpdateOneAsync(user
            => user.Id == userId, updateDef, null, cancellationToken);

        AppUser appUser = await _collection.Find(user
            => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        UpdateDto updateDto = new(
            Email: appUser.Email
        );

        return updateDto;
    }
}