
using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Interfaces;

public interface IEconomyService
{
    public Task<ServiceReponse<List<T>>> GetGovernmentDataByCountryCodeIdAsync<T>(string countryCode);
    public Task<ServiceReponse<List<T>>> GetGDPPerCapitaDataByCountryCodeIdAsync<T>(string countryCode);
}