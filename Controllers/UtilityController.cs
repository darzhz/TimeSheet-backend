using Microsoft.AspNetCore.Mvc;
using TimeSheet.Services;

namespace TimeSheet.Controllers;

public class UtilityController : ControllerBase
{
    private readonly IUtilityService _util;
    public UtilityController(IUtilityService Util){
        _util = Util;
    }

    [HttpGet]
    [Route("api/qualdetail")]
    public IActionResult GetQualificationEntries(){
        return Accepted(_util.GetQualificationEntries());
    }

    [HttpPost]
    [Route("api/listdeciplines")]
    public IActionResult ReturnDeciplinesBasedOnQualification(string qualification){
        return Accepted(_util.ReturnAllDeciplines(qualification));
    }

}
