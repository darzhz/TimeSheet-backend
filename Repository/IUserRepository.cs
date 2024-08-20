using TimeSheet.Models;
using TimeSheet.Models.Payload;

namespace TimeSheet.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsyc(int id);
    Task<User?> GetUserByEmailAsyc(string email);
    Task AddUserAsyc(User user);
    Task<User?> UpdateUserAsyc(User user);
    Task AddUserExp(PreviousExperience pre);
    List<PreviousExperience>? GetPrevExp(int id);
    Task AddQualificationDetails(QualificationDetails qa);
    Task<List<QualificationDetails?>?> GetQualificationDetails(int userid);
    PreviousExperience? UpdatePreviousExp(PreviousExperience prev);
    QualDetailsEditResponse? UpdatEducationdetails(QualificationDetails qua);

    public PreviousExperienceEditResponse? DeletePreviousExp(PreviousExperience prev);
    public QualDetailsEditResponse?DeleteQualDetails(QualificationDetails qual);
    public List<UserDto> GetUserRank();

      public List<Rank>?GetRanks();
      public List<Division>?GetDivisions();
       public List<Role>?GetRoles();
    //    public List<ReportManager>?GetManagers();
     public List<Nationality>?GetNationalities();


}
