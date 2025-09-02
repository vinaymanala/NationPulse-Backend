
using Backend.Core.Interfaces;
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
    private readonly IPerformanceService _service;

    public PerformanceGrowthController(AppDbContext context, IPerformanceService service)
    {
        _context = context;
        _service = service;
    }

    [ApiExplorerSettings(GroupName = Constants.PerformanceApiGroup)]
    [HttpGet("api/gdp/{countryCode}", Name = nameof(GetGDPPerfGrowthByCountry))]
    public async Task<ActionResult> GetGDPPerfGrowthByCountry(string countryCode)
    {
        var data = await _service.GetGDPPerfGrowthByCountryDataAsync<PerfGDPGrowthDto>(countryCode);
        return Ok(data);
    }

    [ApiExplorerSettings(GroupName = Constants.PerformanceApiGroup)]
    [HttpGet("api/population/{countryCode}", Name = nameof(GetPopulationPerfGrowthByCountry))]
    public async Task<ActionResult<IEnumerable<PerfGDPGrowthDto>>> GetPopulationPerfGrowthByCountry(string countryCode)
    {
        var data = await _service.GetPopulationPerfGrowthByCountryDataAsync<PerfPopulationGrowthDto>(countryCode);
        return Ok(data);
    }

}