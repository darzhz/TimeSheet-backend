using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models;
[Table("nations")]
public class Nationality
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("nationality")]
    public string? nationality { get; set; }


}