using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
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
    public IActionResult ReturnDeciplinesBasedOnQualification([FromBody] QualificationInput q){
            return Accepted(_util.ReturnAllDeciplines(q.Qualification));
    }

    [HttpPut("api/qualdetails")]
    public QualDetailsEditResponse? Updatequaldetails([FromBody]QualificationDetails qua){
        return _util.Updatequaldetails(qua);
    }
}
