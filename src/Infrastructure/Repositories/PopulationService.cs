
using Backend.Core.Models.Entities;
using Backend.Infrastructure;
using Backend.Infrastructure.Queries;
using Backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Queries;

public class PopulationRepository : IPopulationRepository
{
    private readonly AppDbContext _context;

    public PopulationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PopulationEntity>> GetPopulationDataByCountryCodeIdAsync(string countryCode)
    {
        FormattableString query = PopulationQuery.GetPopulationByCountryCodeQuery(countryCode);
        var entities = await _context.populationds
       .FromSql(query).ToListAsync();
        return entities;
    }
}