using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TimeSheet.Models;

[Table("nations")]

public class Usernationality
{
 [Required]
 [NotNull]
 [Column("nationality")]

 public string? nationality {get;set;}

   [Required]
   [NotNull]
   [Column("id")]
   public string? ID{get;set;}

}
