namespace TimeSheet.Models;

public class AuthResponce
{
    public string? Message{get;set;}
    public string? Token{get;set;}
    public string? User {get;set;} = null;
    public int? UserId {get;set;} = null;

}
