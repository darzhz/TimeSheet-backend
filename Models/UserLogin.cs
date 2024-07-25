using System.Diagnostics.CodeAnalysis;

namespace TimeSheet.Models;

public class UserLogin
{
    [NotNull]
    public string? Email {get;set;}
    [NotNull]
    public string? Password {get;set;}
}
