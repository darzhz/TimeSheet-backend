using TimeSheet.Models;
using TimeSheet.Models.Payload;
using TimeSheet.Repository;

namespace TimeSheet.Services;

public class UtilityService : IUtilityService
{
    private readonly IUtilityRepository _respository;
    public UtilityService(IUtilityRepository repo)
    {
        _respository = repo;
    }

    public DropDownPayload GetQualificationEntries()
    {
        var payload = new DropDownPayload();

        try
        {
            List<string> data = _respository.GetQualificationEntries();

            if (data != null && data.Count != 0)
            {
                payload.Data = data;
                payload.Message = "Successfully retrieved data";
                payload.Status = System.Net.HttpStatusCode.OK;
            }
            else
            {
                payload.Message = "No data found";
                payload.Status = System.Net.HttpStatusCode.NoContent;
            }
        }
        catch 
        {
            // #TODO add logger service here
            payload.Message = "An error occurred while retrieving data";
            payload.Status = System.Net.HttpStatusCode.InternalServerError;
        }

        return payload;
    }

    public DropDownPayload ReturnAllDeciplines(string qualification){
        var payload = new DropDownPayload();
        try{
            List<string> data = _respository.ReturnAllDesciplines(qualification);
            if (data != null && data.Count != 0)
            {
                payload.Data = data;
                payload.Message = "Successfully retrieved data";
                payload.Status = System.Net.HttpStatusCode.OK;
            }
            else
            {
                payload.Message = "No data found";
                payload.Status = System.Net.HttpStatusCode.NoContent;
            }

        }catch{
            payload.Message = "An error occurred while retrieving data";
            payload.Status = System.Net.HttpStatusCode.InternalServerError;
        }
        return payload;
    }

    
    public QualDetailsEditResponse? Updatequaldetails(QualificationDetails qua)
    {
        return _respository.Updatequaldetails(qua);
    } 



}
