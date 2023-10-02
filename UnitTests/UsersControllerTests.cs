using DotnetApi.Controllers;
using DotnetApi.Services;
using Moq;
using Xunit;

namespace DotnetApi.UnitTests;

public class UsersControllerTests
{
    private readonly UsersController _controller;
    private readonly Mock<IUsersService> _userService;

    public UsersControllerTests()
    {
        _userService = new Mock<IUsersService>();
        _controller = new UsersController(_userService.Object);
    }
    
    
}