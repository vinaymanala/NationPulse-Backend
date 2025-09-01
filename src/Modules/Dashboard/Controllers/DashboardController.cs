
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
    // public readonly string endpointPrefix = { get }";
    public DashboardController(AppDbContext context)
    {
        _context = context;

    }
    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet("api/population/{noOfCountries}", Name = nameof(GetPopulationChartByCountry))]
    public async Task<ActionResult<IEnumerable<PopulationDto>>> GetPopulationChartByCountry(short noOfCountries)
    {
        var isSuccess = default(bool);
        var entities = new List<PerfPopulationGrowthEntity>();
        try
        {
            FormattableString query = DashboardQuery.GetPopulationChartByCountryQuery(noOfCountries);
            entities = await _context.perfgrowthpopulationds
           .FromSql(query).ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching population data", ex);
        }

        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }

    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet($"api/health", Name = nameof(GetHealthChartByCountry))]
    public async Task<ActionResult<IEnumerable<HealthDto>>> GetHealthChartByCountry()
    {
        var isSuccess = default(bool);
        var entities = new List<HealthEntity>();
        try
        {
            FormattableString query = DashboardQuery.GetHealthChartByCountryQuery();
            entities = await _context.healthstatusds
           .FromSql(query).ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching health data:", ex);
        }
        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }

    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet($"api/gdppercapita", Name = nameof(GetGDPPerCapitaChartByCountry))]
    public async Task<ActionResult<IEnumerable<GDPPerCapitaDto>>> GetGDPPerCapitaChartByCountry()
    {
        var isSuccess = default(bool);
        var entities = new List<GDPPerCapitaEntity>();
        try
        {
            FormattableString query = DashboardQuery.GetGDPPerCapitaChartByCountryQuery();
            entities = await _context.gdppercapitads
           .FromSql(query).ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching gdp per capita data :", ex);
        }
        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }






}