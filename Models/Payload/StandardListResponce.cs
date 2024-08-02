namespace TimeSheet.Models.Payload;
using System.Net;

public class StandardListResponce
{
    public string? Message{get;set;}
    public List<QualificationDetails?>? Data {get;set;}
    public HttpStatusCode Status {get;set;}
}
