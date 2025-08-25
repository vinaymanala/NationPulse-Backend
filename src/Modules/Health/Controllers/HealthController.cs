
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
    public HealthController(AppDbContext context)
    {
        _context = context;
    }

    [ApiExplorerSettings(GroupName = Constants.HealthApiGroup)]
    [HttpGet("/api/health/{countryCode}", Name = nameof(GetHealthStatusByCountryCode))]
    public async Task<ActionResult<IEnumerable<HealthEntity>>> GetHealthStatusByCountryCode(string countryCode)
    {
        FormattableString query = HealthQuery.GetHealthStatusByCountryCodeQuery(countryCode);
        var entities = await _context.healthstatusds
        .FromSql(query)
        .ToListAsync();

        return Ok(entities);
    }
}