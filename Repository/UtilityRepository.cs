using System.Data.Common;
using TimeSheet.Models;

namespace TimeSheet.Repository;

public class UtilityRepository : IUtilityRepository
{
    private readonly AppDbContext _context;
    public UtilityRepository(AppDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// This class Returns the Distinct List Of Qualifications if none found returns null
    /// </summary>
    public List<string> GetQualificationEntries()
    {
        try
        {
            return _context.QualificationEntity.Select(q => q.Qualification).Distinct().ToList();
        }
        catch (DbException ex)
        {
            return [$"Something Went Wrong {ex}"];
        }
    }
    /// <summary>
    /// This class Returns the  List Of Desciplines for a given Qualification if none found returns null
    /// </summary>
    public List<string> ReturnAllDesciplines(string qualification)
    {
        try
        {
            return _context.QualificationEntity.Where(qa => qa.Qualification == qualification).Select(q => q.Discipline).ToList<string>();
        }
        catch (DbException ex)
        {
            return [$"Something Went Wrong {ex}"];
        }
    }
    public QualDetailsEditResponse? Updatequaldetails(QualificationDetails qua)
    {
        QualDetailsEditResponse? response = new QualDetailsEditResponse();
        try
        { 
            var qualfromdb =_context.QualificationDetailsEntity.Find(qua.Id);
            if(qualfromdb != null){
                qualfromdb.Qualification=qua.Qualification;
                qualfromdb.Decipline=qua.Decipline;
                qualfromdb.Percentage=qua.Percentage;
                qualfromdb.YearOfPassing=qua.YearOfPassing;
                qualfromdb.university=qua.university;
                qualfromdb.Cgpa=qua.Cgpa;  

                _context.SaveChanges(); 

                response.Message = "Successfully Updated";
                response.qualificationDetails = qualfromdb; 
            }
            else{
                response.Message = "No data found to update";
                response.qualificationDetails = null;
            }
            
        }
        catch(Exception ex)
        {
          response.Message = ex.Message;
          response.qualificationDetails = null;
        }
        return response;
    }


}
