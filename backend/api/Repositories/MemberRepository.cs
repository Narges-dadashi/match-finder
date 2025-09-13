namespace api.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly IMongoCollection<AppUser> _collection;

    public MemberRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }

    public async Task<IEnumerable<AppUser>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<AppUser> appUsers = await _collection.Find
                (new BsonDocument()).ToListAsync(cancellationToken);

        Console.WriteLine(appUsers[1]);

        return appUsers;
    }

    public async Task<MemberDto?> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _collection.Find
            (doc => doc.UserName == userName).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        MemberDto memberDto = Mappers.ConvertAppUserToMemberDto(appUser);

        return memberDto;
    }
}