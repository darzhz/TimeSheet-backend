using System.Net;

namespace TimeSheet.Models;

public class StandardResponce
{
    public string? Message{get;set;}
    public User? User{get;set;}

    public HttpStatusCode? status{get;set;}
}
