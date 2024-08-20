using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models;
[Table("rank")]

public class Rank
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("rank")]
    public string? rank { get; set; }


}