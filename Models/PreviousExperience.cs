using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheet.Models;
[Table("preexp")]
public class PreviousExperience
{
    [Key]
    [Column("id")]
    public int? Id {get;set;}

    [Required]
    [NotNull]
    [Column("compname")]
    public string?CompanyName{get;set;}

    [ForeignKey("Users")]        
    [Column("userid")]
    public int? Userid{get;set;}

    [Required]
    [NotNull]
    [Column("designation")]
    public string? Designation{get;set;}



    [Required]
    [NotNull]
    [Column("statdate")]
    public DateTime? StartDate{get;set;}

    [Required]
    [NotNull]
    [Column("enddate")]
    public DateTime? LastDate{get;set;}

    [Required]
    [NotNull]
    [Column("is_delete")]
    public int Is_Deleted{get;set;} = 0;


}
