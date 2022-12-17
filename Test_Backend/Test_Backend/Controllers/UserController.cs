using Microsoft.AspNetCore.Mvc;
using Test_Backend.Models;
using Test_Backend.Services;

namespace Test_Backend.Controllers;
[Route("/api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Post(User user)
    {
        return _userService.CreateUser(user);
    }

    [HttpPost("login")]
    public JsonResult Login(User user)
    {
        var userLogin =_userService.VerifyLogin(user);
        var userWithToken = _userService.SetRoleAndToken(userLogin);
        return new JsonResult(userWithToken);
    }
}