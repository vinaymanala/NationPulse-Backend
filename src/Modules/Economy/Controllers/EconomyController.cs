
using Backend.Core.Interfaces;
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
    private readonly IEconomyService _service;

    public EconomyController(AppDbContext context, IEconomyService service)
    {
        _context = context;
        _service = service;
    }

    [ApiExplorerSettings(GroupName = Constants.EconomyApiGroup)]
    [HttpGet("api/governmentdata/country/{countryCode}", Name = nameof(GetGovernmentDataByCountryCode))]
    public async Task<ActionResult<IEnumerable<GovernmentDataDto>>> GetGovernmentDataByCountryCode(string countryCode)
    {
        var data = await _service.GetGovernmentDataByCountryCodeIdAsync<GovernmentDataDto>(countryCode);
        return Ok(data);
    }
    [ApiExplorerSettings(GroupName = Constants.EconomyApiGroup)]
    [HttpGet("api/gdppercapita/country/{countryCode}", Name = nameof(GetGDPPerCapitaDataByCountryCode))]
    public async Task<ActionResult<IEnumerable<GovernmentDataDto>>> GetGDPPerCapitaDataByCountryCode(string countryCode)
    {
        var data = await _service.GetGDPPerCapitaDataByCountryCodeIdAsync<GDPPerCapitaDto>(countryCode);
        return Ok(data);
    }
}