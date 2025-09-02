
using Backend.Core.Models.Entities;

namespace Backend.Core.Interfaces;

public interface IEconomyRepository
{
    public Task<List<GovernmentDataEntity>> GetGovernmentDataByCountryCodeIdAsync(string countryCode);
    public Task<List<GDPPerCapitaEntity>> GetGDPPerCapitaDataByCountryCodeIdAsync(string countryCode);
}