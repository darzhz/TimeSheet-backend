using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;

namespace TimeSheet;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> UsersEntity {get;set;}
    public DbSet<QualificationModel> QualificationEntity {get;set;}
    public DbSet<QualificationDetails> QualificationDetailsEntity {get;set;}
    public DbSet<PreviousExperience> Previous {get;set;}
    public DbSet<Nationality> Nationality{get;set;}
    
     public DbSet<Nationality>Nation{get;set;}
        public DbSet<Role>roles{get;set;}
            public DbSet<Rank>ranks{get;set;}
                public DbSet<Division>divisions{get;set;}
               //  public DbSet<ReportManager>ReportManagers{get;set;}




}
