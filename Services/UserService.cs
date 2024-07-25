using TimeSheet.Models;
using TimeSheet.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TimeSheet.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<StandardResponce> AddUserAsyc(User user)
    {
        StandardResponce resp = new();
        try
        {
            var existingUser = await _repository.GetUserByEmailAsyc(user.Email);
            Console.WriteLine(existingUser);
            if (existingUser == null)
            {
                await _repository.AddUserAsyc(user);
                resp.Message = "User added successfully added";
                resp.User = user;
                return resp;
            }
            else
            {
                resp.Message = "User Already Exists";
                resp.User = null;
                return resp;
            }
        }
        catch (System.Exception)
        {
            resp.Message = "something went wrong at Db while inserting user";
            resp.User = user;
            return resp;
            throw;
        }

    }

    public string GenerateJwtToken(string userid)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("yourSecretKey");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
            new Claim(ClaimTypes.NameIdentifier, userid)
            ]),
            Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsyc()
    {
        return await _repository.GetAllUsersAsyc();
    }

    public async Task<AuthResponce> PerformAuthentication(User user)
    {
        AuthResponce resp = new();
        var UserfromDb = await _repository.GetUserByEmailAsyc(user.Email);
        if (UserfromDb == null)
            {
                resp.Message = "Invalid Email or Password";
                resp.Token = null;
                return resp;
            }else{
                
            }
    }
}
