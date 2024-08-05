using System.ComponentModel.DataAnnotations.Schema;

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
    public float? Percentage {get;set;}

    [Column("cgpa")]
    public float? Cgpa {get;set;}
    
}
