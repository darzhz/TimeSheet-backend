using TimeSheet.Models;

namespace TimeSheet.Services;

public interface IUserService
{
    Task<StandardResponce> GetUnfinished();
    string GenerateJwtToken(String userid);
    Task<AuthResponce> PerformAuthentication(UserLogin user);
    Task<StandardResponce> AddUserInParts(Phase phase,User user);
}
