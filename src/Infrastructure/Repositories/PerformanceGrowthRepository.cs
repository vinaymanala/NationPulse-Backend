
using Backend.Core.Models.Entities;
using Backend.Infrastructure;
using Backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Queries;

public class PerformanceGrowthRepository : IPerformanceRepository
{
    private readonly AppDbContext _context;

    public PerformanceGrowthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PerfGDPGrowthEntity>> GetGDPPerfGrowthByCountryIdAsync(string countryCode)
    {
        FormattableString query = PerformanceGrowthQuery.GetPerfGrowthOfGDPQuery(countryCode);
        var entities = await _context.perfgrowthgdpds
       .FromSql(query).ToListAsync();
        return entities;
    }
    public async Task<List<PerfPopulationGrowthEntity>> GetPopulationPerfGrowthByCountryIdAsync(string countryCode)
    {
        FormattableString query = PerformanceGrowthQuery.GetPerfGrowthOfWorkingPopulation(countryCode);
        var entities = await _context.perfgrowthpopulationds
       .FromSql(query).ToListAsync();
        return entities;
    }
}