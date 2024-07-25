using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
using TimeSheet.Services;

namespace TimeSheet.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService UserService){
        _userService = UserService;
    }

    [HttpGet]
    [Route("/api/users")]
    public async Task<IActionResult> GetAll(){
        var users = await _userService.GetAllUsersAsyc();
        return Ok(users);
    }
    [HttpPost]
    [Route("/api/createUser")]
    public async Task<IActionResult> AddUser(User user){
        var resp = await _userService.AddUserAsyc(user);
        return CreatedAtAction(nameof(AddUser),resp);
    }
    
}
