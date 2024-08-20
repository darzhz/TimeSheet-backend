using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models;
[Table("division")]

public class Division
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("division")]
    public string? division { get; set; }


}