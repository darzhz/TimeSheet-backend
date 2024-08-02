using System.Net;

namespace TimeSheet.Models.Payload;

public class DropDownPayload
{
    public string? Message{get;set;}
    public List<string>? Data {get;set;}
    public HttpStatusCode Status {get;set;}
}
