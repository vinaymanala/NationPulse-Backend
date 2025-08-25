
using Backend.Core.Models.Entities;
using Backend.Core.Queries;
using Backend.Core.Utils;
using Backend.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.PerformanceGrowth.Controllers;

[ApiController]
[Route("/performancegrowth/v1")]
public class PerformanceGrowthController : ControllerBase
{
    private readonly AppDbContext _context;

    public PerformanceGrowthController(AppDbContext context)
    {
        _context = context;
    }

    [ApiExplorerSettings(GroupName = Constants.PerformanceApiGroup)]
    [HttpGet("/api/gdp/{countryCode}", Name = nameof(GetGDPPerfGrowthByCountry))]
    public async Task<ActionResult<IEnumerable<PerfGDPGrowthDto>>> GetGDPPerfGrowthByCountry(string countryCode)
    {
        FormattableString query = PerformanceGrowthQuery.GetPerfGrowthOfGDPQuery(countryCode);
        var entities = await _context.perfgrowthgdpds
        .FromSql(query)
        .ToListAsync();

        return Ok(entities);
    }

    [ApiExplorerSettings(GroupName = Constants.PerformanceApiGroup)]
    [HttpGet("/api/population/{countryCode}", Name = nameof(GetPopulationPerfGrowthByCountry))]
    public async Task<ActionResult<IEnumerable<PerfGDPGrowthDto>>> GetPopulationPerfGrowthByCountry(string countryCode)
    {
        FormattableString query = PerformanceGrowthQuery.GetPerfGrowthOfWorkingPopulation(countryCode);
        var entities = await _context.perfgrowthpopulationds
        .FromSql(query)
        .ToListAsync();

        return Ok(entities);
    }

}