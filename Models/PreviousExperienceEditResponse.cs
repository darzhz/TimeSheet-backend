namespace TimeSheet.Models;
using System.Net;
public class PreviousExperienceEditResponse
{
    public string? Message{get;set;}
    public PreviousExperience? UpdatedExperience{get;set;}
    public HttpStatusCode? Status{get;set;}

}
