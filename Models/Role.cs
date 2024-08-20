
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models;
[Table("role")]

public class Role
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("role_of_employee")]
    public string? role { get; set; }


}