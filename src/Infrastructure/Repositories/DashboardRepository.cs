
using Backend.Core.Models.Entities;
using Backend.Infrastructure;
using Backend.Infrastructure.Queries;
using Backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _context;

    public DashboardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PerfPopulationGrowthEntity>> GetPopulationDataByNoOfCountriesAsync(short noOfCountries)
    {
        FormattableString query = DashboardQuery.GetPopulationChartByCountryQuery(noOfCountries);
        var entities = await _context.perfgrowthpopulationds
       .FromSql(query).ToListAsync();
        return entities;
    }

    public async Task<List<HealthEntity>> GetHealthAllAsync()
    {
        FormattableString query = DashboardQuery.GetHealthChartByCountryQuery();
        var entities = await _context.healthstatusds
       .FromSql(query).ToListAsync();
        return entities;
    }

    public async Task<List<GDPPerCapitaEntity>> GetGdpPerCapitaAllAsync()
    {
        FormattableString query = DashboardQuery.GetGDPPerCapitaChartByCountryQuery();
        var entities = await _context.gdppercapitads
       .FromSql(query).ToListAsync();

        return entities;
    }
}