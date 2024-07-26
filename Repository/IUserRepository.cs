using TimeSheet.Models;
using TimeSheet.Models.Payloads;

namespace TimeSheet.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsyc(int id);
    Task<User?> GetUserByEmailAsyc(string email);
    Task<IEnumerable<User>> GetAllUsersAsyc();
    Task<IEnumerable<User>> GetAllIncompleteUsers();
    Task AddUserAsyc(User user);

    Task<User?> UpdateUserAsyc(User user);
}
