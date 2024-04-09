namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DatvContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DatvContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("ApiDatvbase")).
        UseSnakeCaseNamingConvention();
    }

    public DbSet<Datv> Datvs { get; set; }

}