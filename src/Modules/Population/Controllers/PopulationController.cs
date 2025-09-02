
using System.Text.RegularExpressions;

using Backend.Core.Interfaces;
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
    private readonly IPopulationService _service;
    public PopulationController(AppDbContext context, IPopulationService service)
    {
        _context = context;
        _service = service;
    }


    [ApiExplorerSettings(GroupName = Constants.PopulationApiGroup)]
    [HttpGet("api/country/{countryCode}/", Name = nameof(GetPopulationByCountryCode))]
    public async Task<ActionResult> GetPopulationByCountryCode(string countryCode)
    {
        var Response = await _service.GetPopulationDataByCountryCodeAsync<PopulationDto>(countryCode);
        return Ok(Response);
    }
}
