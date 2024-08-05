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
    [Route("/api/adduserinprogression/{phase}")]
    public async Task<StandardResponce> AddUserInProgression(Phase phase, [FromBody] User user)
    {
        return await _userService.AddUserInParts(phase,user);
    } 


    [HttpPost]
    [Route("/api/login")]
    public async Task<IActionResult> LoginUser(UserLogin user)
    {
        var resp = await _userService.PerformAuthentication(user);
        return Ok(resp);
    }

    [HttpPost]
    [Route("/api/preexp")]
    public async Task<StandardResponce> AddPreviousExpreience (PreviousExperience preexp){
        return await _userService.AddUserExp(preexp);
    }

    // [HttpGet("getpexp")]
    // public Task<IEnumerable>getExp()
    // {
    //     return _userService.getExp();
    // }

    [HttpGet("/api/GetPrevExp/{id}")]
    public List<PreviousExperience>? GetPrevExp(int id)
    {

        return _userService.GetPrevExp(id);
    }
}

