using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;
using TimeSheet.Models.Payloads;

namespace TimeSheet.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context){
        _context = context;
    }

    public async Task AddUserAsyc(User user)
    {
        _context.UsersEntity.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllIncompleteUsers()
    {
        //#TODO findiing null elements test cheyth nokkk
        return await _context.UsersEntity.Where(u=>u.BldGrp == null).ToListAsync();
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
}
