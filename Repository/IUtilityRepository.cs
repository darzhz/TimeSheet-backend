using System.Collections.Generic;
using TimeSheet.Models;

namespace TimeSheet.Repository;

public interface IUtilityRepository
{
    public List<string> GetQualificationEntries();
    public List<string> ReturnAllDesciplines(string qualification);
    public QualDetailsEditResponse? Updatequaldetails(QualificationDetails qua);
}
