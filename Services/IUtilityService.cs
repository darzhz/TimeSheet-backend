using TimeSheet.Models.Payload;
using TimeSheet.Repository;

namespace TimeSheet.Services;

public interface IUtilityService
{
    public DropDownPayload GetQualificationEntries();
    public DropDownPayload ReturnAllDeciplines(string qualification);
}
