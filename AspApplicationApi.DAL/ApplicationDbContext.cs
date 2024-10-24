using Microsoft.EntityFrameworkCore;

namespace AspApplication.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
      
    }    
    public DbSet<AspApplication.Domain.Entity.Application> AllApplications { get; set; }
    
}
