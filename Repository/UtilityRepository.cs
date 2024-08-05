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


}
