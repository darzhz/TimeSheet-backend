using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;

namespace TimeSheet;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> UsersEntity {get;set;}
}
