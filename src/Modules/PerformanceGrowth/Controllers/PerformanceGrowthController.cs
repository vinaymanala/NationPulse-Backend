
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
    [HttpGet("api/gdp/{countryCode}", Name = nameof(GetGDPPerfGrowthByCountry))]
    public async Task<ActionResult<IEnumerable<PerfGDPGrowthDto>>> GetGDPPerfGrowthByCountry(string countryCode)
    {
        var isSuccess = default(bool);
        var entities = new List<PerfGDPGrowthEntity>();
        try
        {
            FormattableString query = PerformanceGrowthQuery.GetPerfGrowthOfGDPQuery(countryCode);
            entities = await _context.perfgrowthgdpds
            .FromSql(query)
            .ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching performance growth gdp data :", ex);
        }

        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }

    [ApiExplorerSettings(GroupName = Constants.PerformanceApiGroup)]
    [HttpGet("api/population/{countryCode}", Name = nameof(GetPopulationPerfGrowthByCountry))]
    public async Task<ActionResult<IEnumerable<PerfGDPGrowthDto>>> GetPopulationPerfGrowthByCountry(string countryCode)
    {
        var isSuccess = default(bool);
        var entities = new List<PerfPopulationGrowthEntity>();
        try
        {
            FormattableString query = PerformanceGrowthQuery.GetPerfGrowthOfWorkingPopulation(countryCode);
            entities = await _context.perfgrowthpopulationds
            .FromSql(query)
            .ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching performance growth population data", ex);
        }

        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }

}