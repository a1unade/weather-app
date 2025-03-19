using Microsoft.EntityFrameworkCore;
using ServiceC.Web.Entities;

namespace ServiceC.Web.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<WeatherRecord> WeatherRecords { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}