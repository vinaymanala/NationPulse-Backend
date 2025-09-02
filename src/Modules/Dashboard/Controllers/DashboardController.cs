
using Backend.Core.Interfaces;
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
    private readonly IDashboardService _service;
    // public readonly string endpointPrefix = { get }";
    public DashboardController(AppDbContext context, IDashboardService service)
    {
        _context = context;
        _service = service;

    }
    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet("api/population/{noOfCountries}", Name = nameof(GetPopulationChartByCountry))]
    public async Task<ActionResult> GetPopulationChartByCountry(short noOfCountries)
    {
        var Response = await _service.GetPopulationDataAsync<PopulationDto>(noOfCountries);
        return Ok(Response);
    }

    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet($"api/health", Name = nameof(GetHealthChartByCountry))]
    public async Task<ActionResult> GetHealthChartByCountry()
    {
        var Response = await _service.GetHealthDataAsync<HealthDto>();
        return Ok(Response);
    }

    [ApiExplorerSettings(GroupName = Constants.DashboardApiGroup)]
    [HttpGet($"api/gdppercapita", Name = nameof(GetGDPPerCapitaChartByCountry))]
    public async Task<ActionResult> GetGDPPerCapitaChartByCountry()
    {
        var Response = await _service.GetGdpPerCapitaDataAsync<GDPPerCapitaDto>();
        return Ok(Response);
    }






}