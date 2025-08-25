
using Backend.Core.Models.Entities;
using Backend.Core.Utils;
using Backend.Infrastructure;
using Backend.Infrastructure.Queries;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Dashboard.Controllers;

[ApiController]
[Route("/dashboard/v1")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }
    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet("/api/population", Name = nameof(GetPopulationChartByCountry))]
    public async Task<ActionResult<IEnumerable<PopulationDto>>> GetPopulationChartByCountry()
    {
        FormattableString query = DashboardQuery.GetPopulationChartByCountryQuery();
        var entities = await _context.perfgrowthpopulationds
        .FromSql(query).ToListAsync();
        return Ok(entities);
    }

    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet("/api/health", Name = nameof(GetHealthChartByCountry))]
    public async Task<ActionResult<IEnumerable<HealthDto>>> GetHealthChartByCountry()
    {
        FormattableString query = DashboardQuery.GetHealthChartByCountryQuery();
        var entities = await _context.healthstatusds
        .FromSql(query).ToListAsync();
        return Ok(entities);
    }

    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet("/api/gdppercapita", Name = nameof(GetGDPPerCapitaChartByCountry))]
    public async Task<ActionResult<IEnumerable<GDPPerCapitaDto>>> GetGDPPerCapitaChartByCountry()
    {
        FormattableString query = DashboardQuery.GetGDPPerCapitaChartByCountryQuery();
        var entities = await _context.gdppercapitads
        .FromSql(query).ToListAsync();
        return Ok(entities);
    }






}