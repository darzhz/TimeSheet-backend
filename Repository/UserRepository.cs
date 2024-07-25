using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;

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
        //findiing null elements test cheyth nokkk
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

    public async Task UpdateUserAsyc(User user)
    {
          _context.UsersEntity.Update(user);
          await _context.SaveChangesAsync();
    }
}
