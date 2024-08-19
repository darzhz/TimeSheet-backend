using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheet.Models;
[Table("div and role _employee")]

public class UserDivandRoleEmolyee
{
  [Required]
  [NotNull]
  [Column("div")]
  public string? divofemployee{get;set;}
  
  [Required]
  [NotNull]
  [Column("role")]
  public string? Role{get;set;}


   [Required]
   [NotNull]
   [Column("id")]
   public string? ID{get;set;}
}
