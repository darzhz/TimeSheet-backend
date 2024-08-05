using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;


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
    


    public async Task<IEnumerable<User>> GetAllUsersAsyc()
    {
       return await _context.UsersEntity.ToListAsync();
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
        return await _context.QualificationDetailsEntity.Where(qa => qa.Userid == userid).ToListAsync<QualificationDetails?>();
    }
    public async Task AddUserExp(PreviousExperience pre)
    {
        _context.Previous.Add(pre);
        await _context.SaveChangesAsync();
    }

    public List<PreviousExperience>? GetPrevExp(int id)
    {
        var prex = _context.Previous.Where(p => p.Userid == id).ToList<PreviousExperience>();
        return prex;
    }
}







