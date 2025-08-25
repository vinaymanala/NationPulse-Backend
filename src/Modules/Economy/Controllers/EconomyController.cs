
using Backend.Core.Models.Entities;
using Backend.Core.Queries;
using Backend.Core.Utils;
using Backend.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Economy;

[ApiController]
[Route("/economy/v1")]
public class EconomyController : ControllerBase
{
    private readonly AppDbContext _context;

    public EconomyController(AppDbContext context)
    {
        _context = context;
    }

    [ApiExplorerSettings(GroupName = Constants.EconomyApiGroup)]
    [HttpGet("/api/governmentdata/country/{countryCode}", Name = nameof(GetGovernmentDataByCountryCode))]
    public async Task<ActionResult<IEnumerable<GovernmentDataDto>>> GetGovernmentDataByCountryCode(string countryCode)
    {
        FormattableString query = EconomyQuery.GetGovernmentDataByCountryCodeQuery(countryCode);
        var entities = await _context.publicgovernmentyearlyds
        .FromSql(query)
        .ToListAsync();

        return Ok(entities);
    }
    [ApiExplorerSettings(GroupName = Constants.EconomyApiGroup)]
    [HttpGet("/api/gdppercapita/country/{countryCode}", Name = nameof(GetGovernmentDataByCountryCode))]
    public async Task<ActionResult<IEnumerable<GovernmentDataDto>>> GetGDPPerCapitaDataByCountryCode(string countryCode)
    {
        FormattableString query = EconomyQuery.GetGDPPerCapitaDataByCountryCodeQuery(countryCode);
        var entities = await _context.gdppercapitads
        .FromSql(query)
        .ToListAsync();

        return Ok(entities);
    }
}