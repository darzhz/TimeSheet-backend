using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheet.Models;

[Table("qualentry")]
public class QualificationModel
{
    [Key]
    [Column("id")]
    public int Id {get;set;}

    [Required]
    [NotNull]
    [Column("qualification")]
    public string? Qualification {get;set;}

    [Required]
    [NotNull]
    [Column("discipline")]
    public string? Discipline {get;set;}

}
