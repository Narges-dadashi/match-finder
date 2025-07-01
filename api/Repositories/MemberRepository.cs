namespace api.Repositories;

public class MemberRepository : IMemberRepository
{
    #region Db and Token Settings
    private readonly IMongoCollection<AppUser> _collection;

    // constructor - dependency injections
    public MemberRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }
    #endregion

    public async Task<List<AppUser>?> GetAllAsync(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);

        if (appUsers.Count == 0)
            return null;

        return appUsers;
    }

    public async Task<MemberDto?> GetByUserNameAsync(string UserName, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _collection.Find
            (doc => doc.UserName == UserName).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        MemberDto memberDto = Mappers.ConvertAppUserToMemberDto(appUser);

        return memberDto;
    } 
}