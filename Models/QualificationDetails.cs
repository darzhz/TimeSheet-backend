using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace TimeSheet.Models;

[Table("qualification")]
public class QualificationDetails
{
    [Column("id")]
    public int? Id{get;set;}
    
    [Column("userid")]
    [ForeignKey(nameof(User))]
    public int Userid {get;set;}

    [Column("qualification")]
    public string? Qualification {get;set;}

    [Column("decipline")]
    public string? Decipline {get;set;}

    [Column("university")]
    public string? university {get;set;}

    [Column("yearofpassing")]
    public int? YearOfPassing {get;set;}

    [Column("percentage")]
    [AllowNull]
    public float? Percentage {get;set;} = null;

    [Column("cgpa")]
    [AllowNull]
    public float? Cgpa {get;set;} = null;

    [Required]
    [NotNull]
    [Column("is_delete")]
    public int Is_Deleted {get;set;}=0;
    
}
