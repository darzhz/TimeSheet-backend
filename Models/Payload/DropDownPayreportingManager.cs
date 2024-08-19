using System;
using System.Net;

namespace TimeSheet.Models.Payload;

public class DropDownPayreportingManager
{
public string? Message{get;set;}
    public List<DropDownUser>? Data {get;set;}
    public HttpStatusCode Status {get;set;}
}
