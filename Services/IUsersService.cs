using DotnetApi.Models;

namespace DotnetApi.Services;

public interface IUsersService
{
    Task<IReadOnlyCollection<User>> GetUsersAsync();

    Task<User?> GetUserAsync(string id);

    Task CreateUserAsync(User newUser);

    Task UpdateUserAsync(string id, User updatedUser);

    Task RemoveUserAsync(string id);
}