using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
using TimeSheet.Services;

namespace TimeSheet.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService UserService)
    {
        _userService = UserService;
    }

    [Authorize]
    [HttpGet]
    [Route("/api/users")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsyc();
        return Ok(users);
    }
    [HttpPost]
    [Route("/api/createUser")]
    public async Task<IActionResult> AddUser(User user)
    {
        var resp = await _userService.AddUserAsyc(user);
        return CreatedAtAction(nameof(AddUser), resp);
    }

    [HttpPost]
    [Route("/api/adduserinprogression{phase}")]
    public async Task<StandardResponce> AddUserInProgression(Phase phase, [FromBody] User user)
    {
        return await _userService.AddUserInParts(phase,user);
    }

    [HttpPut]
    [Route("/api/adduserinprogression{phase}")]
    public async Task<StandardResponce> UpdateUserInProgression(Phase phase, [FromBody] User user)
    {
        return await _userService.AddUserInParts(phase,user);
    }

    [HttpPost]
    [Route("/api/login")]
    public async Task<IActionResult> LoginUser(UserLogin user)
    {
        var resp = await _userService.PerformAuthentication(user);
        return CreatedAtAction(nameof(LoginUser), resp);
    }

}

