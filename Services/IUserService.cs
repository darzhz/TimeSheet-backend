using TimeSheet.Models;

namespace TimeSheet.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsyc();
    Task<StandardResponce> AddUserAsyc(User user);
    string GenerateJwtToken(String userid);
    Task<AuthResponce> PerformAuthentication(UserLogin user);
    Task<StandardResponce> AddUserInParts(Phase phase,User user);
    // Task<StandardResponce> UpdateUsersInParts(Phase phase,User user); #TODO IMPLEMENT UPDATE IN PARTS
}
