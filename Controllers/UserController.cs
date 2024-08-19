using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
using TimeSheet.Models.Payload;
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
    [Route("/api/EducationalDetails")]
    public async Task<StandardResponce> PostEducationDetails(QualificationDetails Qd){
       return  await _userService.AddQualificationDetails(Qd);
    }
    [HttpGet]
    [Route("/api/EducationalDetails/{userid}")]
    public async Task<StandardListResponce> GetEducationDetails(int userid){
       return  await _userService.GetQualificationDetails(userid);
    }
    [HttpPut]
    [Route("/api/EducationalDetails")]
    public QualDetailsEditResponse? UpdateEducationDetails(QualificationDetails Qd){
       return  _userService.UpdatEducationdetails(Qd);
    }

    [HttpPost]
    [Route("/api/preexp")]
    public async Task<StandardResponce> AddPreviousExpreience (PreviousExperience preexp){
        return await _userService.AddUserExp(preexp);
    }

    [HttpGet("/api/GetPrevExp/{id}")]
    public List<PreviousExperience>? GetPrevExp(int id)
    {

        return _userService.GetPrevExp(id);
    }

    [HttpPut]
    [Route("/api/preexp")]
    public PreviousExperienceEditResponse UpdatePreviousExperience(PreviousExperience prex){
        return _userService.UpdatePreviousExp(prex);
    }

    [HttpDelete]
    [Route("/api/preexp")]
    public PreviousExperienceEditResponse? DeletePreviousExp([FromBody] PreviousExperience prex){
        return _userService.DeletePreviousExp(prex);
    }
    

    [HttpDelete]
    [Route("/api/EducationalDetails")]
    public QualDetailsEditResponse?DeleteQualDetails(QualificationDetails qual){
        return _userService.DeleteQualDetails(qual);
    }

    
    [HttpGet]
    [Route("/api/ReportingManager")]
     public List<UserDto> GetUserRank(){
        return _userService.GetUserRank();
    }
    
    

}


