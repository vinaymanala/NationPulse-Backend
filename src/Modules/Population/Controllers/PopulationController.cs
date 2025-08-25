
using System.Text.RegularExpressions;

using Backend.Core.Models.Entities;
using Backend.Core.Queries;
using Backend.Core.Utils;
using Backend.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Population.Controllers;

[ApiController]
[Route("/population/v1")]
public class PopulationController : ControllerBase
{
    private readonly AppDbContext _context;
    public PopulationController(AppDbContext context)
    {
        _context = context;
    }


    [ApiExplorerSettings(GroupName = Constants.PopulationApiGroup)]
    [HttpGet("/api/population/{countryCode}/", Name = nameof(GetPopulationByCountryCode))]
    public async Task<ActionResult<IEnumerable<PopulationDto>>> GetPopulationByCountryCode(string countryCode)
    {
        FormattableString query = PopulationQuery.GetPopulationByCountryCodeQuery(countryCode);
        var entities = await _context.populationds
        .FromSql(query)
        .ToListAsync();
        return Ok(entities);
    }
}
