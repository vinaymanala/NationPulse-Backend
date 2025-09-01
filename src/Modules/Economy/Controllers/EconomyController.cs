
using Backend.Core.Models.Entities;
using Backend.Core.Queries;
using Backend.Core.Utils;
using Backend.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Modules.Economy;

[ApiController]
[Route("/economy/v1")]
public class EconomyController : ControllerBase
{
    private readonly AppDbContext _context;

    public EconomyController(AppDbContext context)
    {
        _context = context;
    }

    [ApiExplorerSettings(GroupName = Constants.EconomyApiGroup)]
    [HttpGet("api/governmentdata/country/{countryCode}", Name = nameof(GetGovernmentDataByCountryCode))]
    public async Task<ActionResult<IEnumerable<GovernmentDataDto>>> GetGovernmentDataByCountryCode(string countryCode)
    {
        var isSuccess = default(bool);
        var entities = new List<GovernmentDataEntity>();
        try
        {
            FormattableString query = EconomyQuery.GetGovernmentDataByCountryCodeQuery(countryCode);
            entities = await _context.publicgovernmentyearlyds
            .FromSql(query)
            .ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching government data", ex);
        }
        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }
    [ApiExplorerSettings(GroupName = Constants.EconomyApiGroup)]
    [HttpGet("api/gdppercapita/country/{countryCode}", Name = nameof(GetGDPPerCapitaDataByCountryCode))]
    public async Task<ActionResult<IEnumerable<GovernmentDataDto>>> GetGDPPerCapitaDataByCountryCode(string countryCode)
    {
        var isSuccess = default(bool);
        var entities = new List<GDPPerCapitaEntity>();
        try
        {
            FormattableString query = EconomyQuery.GetGDPPerCapitaDataByCountryCodeQuery(countryCode);
            entities = await _context.gdppercapitads
           .FromSql(query)
           .ToListAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching gdp per capita data", ex);
        }
        var Response = new
        {
            data = entities,
            isSuccess = isSuccess.ToString(),
        };
        return Ok(Response);
    }
}