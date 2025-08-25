
using System.Diagnostics.CodeAnalysis;

using Backend.Core.Models.Entities;

using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure;


public partial class AppDbContext : DbContext
{
    protected void OnCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PopulationEntity>().ToTable("populationds");

        modelBuilder.Entity<HealthEntity>().ToTable("healthstatusds");

        modelBuilder.Entity<HealthEntity>().ToTable("gdppercapitads");

        modelBuilder.Entity<GovernmentDataEntity>().ToTable("publicgovernmentyearlyds");

        modelBuilder.Entity<PerfPopulationGrowthEntity>().ToTable("perfgrowthpopulationds");

        modelBuilder.Entity<PerfGDPGrowthEntity>().ToTable("perfgrowthgdpds");

    }
    public DbSet<PopulationEntity> populationds { get; set; }

    public DbSet<HealthEntity> healthstatusds { get; set; }

    public DbSet<GDPPerCapitaEntity> gdppercapitads { get; set; }

    public DbSet<GovernmentDataEntity> publicgovernmentyearlyds { get; set; }

    public DbSet<PerfPopulationGrowthEntity> perfgrowthpopulationds { get; set; }

    public DbSet<PerfGDPGrowthEntity> perfgrowthgdpds { get; set; }



}