using DotnetApi.Models;
using DotnetApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApi.Controllers;

// [ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService) =>
        _usersService = usersService;

    [HttpGet]
    public async Task<IReadOnlyCollection<User>> GetUsersAsync() =>
        await _usersService.GetUsersAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> GetUserAsync(string id)
    {
        var user = await _usersService.GetUserAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUserAsync(User newUser)
    {
        await _usersService.CreateUserAsync(newUser);

        return CreatedAtAction(
            null, // nameof(Get)
            new { id = newUser.Id },
            newUser);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<ActionResult> UpdateUserAsync(
        string id,
        User updatedUser)
    {
        var user = await _usersService.GetUserAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.Id = user.Id;

        await _usersService
        .UpdateUserAsync(
            id,
            updatedUser);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> DeleteUserAsync(string id)
    {
        var user = await _usersService.GetUserAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await _usersService.RemoveUserAsync(id);

        return NoContent();
    }
}