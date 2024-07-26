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

    [HttpPost]
    [Route("/api/adduserinprogression{phase}")]
    public async Task<StandardResponce> AddUserInProgression(Phase phase, [FromBody] User user)
    {
        return await _userService.AddUserInParts(phase,user);
    }    // #TODO ADD CONTROLLER TO UPDATE IN PROGRESSION


    [HttpPost]
    [Route("/api/login")]
    public async Task<IActionResult> LoginUser(UserLogin user)
    {
        var resp = await _userService.PerformAuthentication(user);
        return CreatedAtAction(nameof(LoginUser), resp);
    }

    // [HttpGet]
    // [Route("/api/getUnfinished")]
    // public async Task<IActionResult> GetUnFinished()
    // {
    //     var resp = await
    // }

}

