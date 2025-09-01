
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
    [HttpGet("api/country/{countryCode}", Name = nameof(GetHealthStatusByCountryCode))]
    public async Task<ActionResult<IEnumerable<HealthEntity>>> GetHealthStatusByCountryCode(string countryCode)
    {
        var isSuccess = default(bool);
        var entities = new List<HealthEntity>();
        try
        {
            FormattableString query = HealthQuery.GetHealthStatusByCountryCodeQuery(countryCode);
            entities = await _context.healthstatusds
           .FromSql(query)
           .ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching health data", ex);
        }
        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }
}