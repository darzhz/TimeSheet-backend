using TimeSheet.Models;
using TimeSheet.Models.Payload;

namespace TimeSheet.Services;

public interface IUserService
{
    string GenerateJwtToken(String userid);
    Task<AuthResponce> PerformAuthentication(UserLogin user);
    public Task<StandardResponce> AddUserInParts(User user);

    Task<StandardResponce> AddQualificationDetails(QualificationDetails qa);
    Task<StandardListResponce> GetQualificationDetails(int userid);
    Task<StandardResponce> AddUserExp(PreviousExperience ex);
    List<PreviousExperience>? GetPrevExp(int id);
    PreviousExperienceEditResponse UpdatePreviousExp(PreviousExperience pre);
    public QualDetailsEditResponse? UpdatEducationdetails(QualificationDetails qua);
    public PreviousExperienceEditResponse? DeletePreviousExp(PreviousExperience prev);
    public QualDetailsEditResponse?DeleteQualDetails(QualificationDetails qual);
    public List<UserDto> GetUserRank();

      public List<Rank>?GetRanks();
      public List<Division>?GetDivisions();
       public List<Role>?GetRoles();
        public List<Nationality>?GetNationalities();



}
