using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheet.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public int UserId{get;set;}
    [Required]
    [Column("username")]
    public string? UserName {get;set;}
    [Required]
    [NotNull]
    [Column("email")]
    public string? Email {get;set;}
    [Required]
    [NotNull]
    [Column("password")]
    public string? Password {get;set;}

}
