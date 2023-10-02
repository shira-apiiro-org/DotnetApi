using DotnetApi.Models;

namespace DotnetApi.DataStore;

public class UserCollectionStorage : IUserCollectionStorage
{
    public Task<IReadOnlyCollection<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task CreateUserAsync(User newUser)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(string id, User updatedUser)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUserAsync(string id)
    {
        throw new NotImplementedException();
    }
}