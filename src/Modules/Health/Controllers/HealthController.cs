
using Backend.Core.Interfaces;
using Backend.Core.Models.Entities;
using Backend.Core.Queries;
using Backend.Core.Utils;
using Backend.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Health.Controllers;

[ApiController]
[Route("/health/v1")]

public class HealthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IHealthService _service;
    public HealthController(AppDbContext context, IHealthService service)
    {
        _context = context;
        _service = service;
    }

    [ApiExplorerSettings(GroupName = Constants.HealthApiGroup)]
    [HttpGet("api/country/{countryCode}", Name = nameof(GetHealthStatusByCountryCode))]
    public async Task<ActionResult> GetHealthStatusByCountryCode(string countryCode)
    {
        var data = await _service.GetHealthDataByCountryCodeAsync<HealthDto>(countryCode);
        return Ok(data);
    }
}