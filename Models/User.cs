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
    [Column("password")]
    public string? Password {get;set;}
    
    [Column("firstname")]
    public string? Fname {get;set;}

    [Column("lastname")]
    public string? Lname {get;set;}

    [Column("maritalstatus")]
    public string? Mstatus {get;set;}

    [Column("pancardno")]
    public string? PanNum {get;set;}

    [Column("temp_address")]
    public string? TempAddr{get;set;}

    [Column("aadhar_no")]
    public string? AadhaarNum{get;set;}

    [Column("perm_address")]
    public String? PermAddr{get;set;}

    [Column("ph_no")]
    public string? PhNum {get;set;}

    [Column("gender")]
    public string? Gender {get;set;}

    [Column("blood_grp")]
    public string? BldGrp {get;set;}

    public static implicit operator Task<object>(User v)
    {
        throw new NotImplementedException();
    }
}
