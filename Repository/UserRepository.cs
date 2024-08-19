using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;
using TimeSheet.Models.Payload;


namespace TimeSheet.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context){
        _context = context;
    }

    public async Task AddQualificationDetails(QualificationDetails qa)
    {
         _context.QualificationDetailsEntity.Add(qa);
         await _context.SaveChangesAsync();
    }
    // public async Task<QualificationDetails> Get

    public async Task AddUserAsyc(User user)
    {
        _context.UsersEntity.Add(user);
        await _context.SaveChangesAsync();
    }
    

    public async Task<User?> GetUserByEmailAsyc(string email)
    {
        try{
            return await _context.UsersEntity.Where(us => us.Email == email).SingleAsync();
        }catch(InvalidOperationException){
            return null;
        }
        
    }

    public async Task<User?> GetUserByIdAsyc(int id)
    {
        return await _context.UsersEntity.FindAsync(id);
    }
    // #TODO  duplicate data is allowed in educational qualification
    public PreviousExperience? UpdatePreviousExp(PreviousExperience prev){
        try
        {
            var PrexFromDb = _context.Previous.Where(p=> p.Id == prev.Id && p.Is_Deleted != 1).FirstOrDefault();
            if(PrexFromDb == null){
                return null;
            }else{
                PrexFromDb.CompanyName = prev.CompanyName;
                PrexFromDb.Designation = prev.Designation;
                PrexFromDb.LastDate = prev.LastDate;
                PrexFromDb.StartDate = prev.StartDate;
                _context.SaveChanges();
                return PrexFromDb;
            }
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public PreviousExperienceEditResponse? DeletePreviousExp(PreviousExperience prev)
    {
        // #TODO change edit to delete
        PreviousExperienceEditResponse? resp= new PreviousExperienceEditResponse();
        try{
            var PreviousExperienceFromDb = _context.Previous.Where(p=> p.Id == prev.Id && p.Is_Deleted != 1).FirstOrDefault();
            if(PreviousExperienceFromDb != null){
                PreviousExperienceFromDb.Is_Deleted = 1;
                _context.SaveChanges();
                
                resp.Message="Your Previous experience has been deleted successfully.";
                resp.UpdatedExperience=PreviousExperienceFromDb;

            }
            else{
                resp.Message="Data not found";
                resp.UpdatedExperience=null;
            }
        } 

        catch(System.Exception){
            resp.UpdatedExperience=null;
            resp.Message="Something went wrong";
        }
        return resp;
    }

    public QualDetailsEditResponse?DeleteQualDetails(QualificationDetails qual)
    {
    QualDetailsEditResponse? resp= new QualDetailsEditResponse();
    {
        try{
            var QualDetailsFromDb=_context.QualificationDetailsEntity.Where(p=> p.Id == qual.Id && p.Is_Deleted != 1).FirstOrDefault();
            if(QualDetailsFromDb !=null){
                QualDetailsFromDb.Is_Deleted=1;
                _context.SaveChanges();
                 
                 resp.Message="Sucessfully Deleted";
                 resp.qualificationDetails=QualDetailsFromDb;
            }
            else{
                resp.Message="Data not found";
                resp.qualificationDetails=null;
            }
        }
        catch (System.Exception){
            resp.Message="Something went wrong";
            resp.qualificationDetails=null;

        }
    }
    return resp;
    }

    public async Task<User?> UpdateUserAsyc(User user)
    {
        try{
            User UserFromDb =  await _context.UsersEntity.Where(us => us.Email == user.Email).SingleAsync();
            if(UserFromDb == null){
                return null;
            }else{
                UserFromDb.Email = user.Email;
                UserFromDb.Fname = user.Fname;
                UserFromDb.Lname = user.Lname;
                UserFromDb.Mstatus = user.Mstatus;
                UserFromDb.PanNum = user.PanNum;
                UserFromDb.TempAddr = user.TempAddr;
                UserFromDb.AadhaarNum = user.AadhaarNum;
                UserFromDb.PermAddr = user.PermAddr;
                UserFromDb.PhNum = user.PhNum;
                UserFromDb.Gender = user.Gender;
                UserFromDb.BldGrp = user.BldGrp;
                await _context.SaveChangesAsync();
                return UserFromDb;
            }
        }catch(DbException ){
            return null;
        }

    }
     public async Task<List<QualificationDetails?>?> GetQualificationDetails(int userid)
    {
        return await _context.QualificationDetailsEntity.Where(qa => qa.Userid == userid && qa.Is_Deleted != 1).OrderByDescending(x=>x.Id).ToListAsync<QualificationDetails?>();
    }
    public async Task AddUserExp(PreviousExperience pre)
    {
        _context.Previous.Add(pre);
        await _context.SaveChangesAsync();
    }

    public List<PreviousExperience>? GetPrevExp(int id)
    {
        var prex = _context.Previous.Where(p => p.Userid == id && p.Is_Deleted != 1).OrderByDescending(x=>x.Id).ToList<PreviousExperience>();
        return prex;
    }

    public QualDetailsEditResponse? UpdatEducationdetails(QualificationDetails qua)
    {
        QualDetailsEditResponse? response = new QualDetailsEditResponse();
        try
        { 
            var qualfromdb =_context.QualificationDetailsEntity.Find(qua.Id);
            if(qualfromdb != null){
                qualfromdb.Qualification=qua.Qualification;
                qualfromdb.Discipline=qua.Discipline;
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
    public List<UserDto> GetUserRank()
{
    return _context.UsersEntity
        .Where(u => u.Rank != "executive" && u.IsDeleted != 1)
        .Select(u => new UserDto 
        { 
            UserId = u.UserId, 
            Email = u.Email 
        })
        .ToList();
}
    

    
    
}








