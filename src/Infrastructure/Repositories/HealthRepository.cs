
using Backend.Core.Models.Entities;
using Backend.Infrastructure;
using Backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Queries;

public class HealthRepository : IHealthRepository
{
    private readonly AppDbContext _context;

    public HealthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<HealthEntity>> GetHealthDataByCountryCodeIdAsync(string countryCode)
    {
        FormattableString query = HealthQuery.GetHealthStatusByCountryCodeQuery(countryCode);
        var entities = await _context.healthstatusds
       .FromSql(query).ToListAsync();
        return entities;
    }
}