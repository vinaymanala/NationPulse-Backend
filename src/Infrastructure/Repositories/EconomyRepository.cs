
using Backend.Core.Models.Entities;
using Backend.Infrastructure;
using Backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Queries;

public class EconomyRepository : IEconomyRepository
{
    private readonly AppDbContext _context;

    public EconomyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GovernmentDataEntity>> GetGovernmentDataByCountryCodeIdAsync(string countryCode)
    {
        FormattableString query = EconomyQuery.GetGovernmentDataByCountryCodeQuery(countryCode);
        var entities = await _context.publicgovernmentyearlyds
       .FromSql(query).ToListAsync();
        return entities;
    }

    public async Task<List<GDPPerCapitaEntity>> GetGDPPerCapitaDataByCountryCodeIdAsync(string countryCode)
    {
        FormattableString query = EconomyQuery.GetGDPPerCapitaDataByCountryCodeQuery(countryCode);
        var entities = await _context.gdppercapitads
       .FromSql(query).ToListAsync();
        return entities;
    }
}