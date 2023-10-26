using Microsoft.EntityFrameworkCore;
namespace SchoolApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Salle> Salles { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}
