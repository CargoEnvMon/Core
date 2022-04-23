using Microsoft.EntityFrameworkCore;

namespace CargoEnvMon.Web.DataLayer;

public class CargoEnvMonDbContext : DbContext
{
    private readonly IConfiguration configuration;
    public DbSet<Shipment> Shipments { get; set; } = null!;
    public DbSet<Cargo> Cargos { get; set; } = null!;
    public DbSet<Measurement> Measurements { get; set; } = null!;

    public CargoEnvMonDbContext()
    {
        configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();
    }

    public CargoEnvMonDbContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("Db"));
    }
}