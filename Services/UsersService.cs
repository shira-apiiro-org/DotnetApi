using DotnetApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetApi.Services;

public class UsersService : IUsersService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(IOptions<UserDatabaseSettings> userDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            userDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            userDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(
            userDatabaseSettings.Value.UsersCollectionName);
    }

    public async Task<IReadOnlyCollection<User>> GetUsersAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetUserAsync(string id) =>
        await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();

    public async Task CreateUserAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateUserAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(user => user.Id == id, updatedUser);

    public async Task RemoveUserAsync(string id) =>
        await _usersCollection.DeleteOneAsync(user => user.Id == id);
}