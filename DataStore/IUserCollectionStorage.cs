using DotnetApi.Models;

namespace DotnetApi.DataStore;

public interface IUserCollectionStorage
{
    Task<IReadOnlyCollection<User>> GetUsersAsync();

    Task<User?> GetUserAsync(string id);

    Task CreateUserAsync(User newUser);

    Task UpdateUserAsync(string id, User updatedUser);

    Task RemoveUserAsync(string id);
}