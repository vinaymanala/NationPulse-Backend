using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Interfaces;

public interface IPerformanceService
{
    public Task<ServiceReponse<List<T>>> GetGDPPerfGrowthByCountryDataAsync<T>(string countryCode);
    public Task<ServiceReponse<List<T>>> GetPopulationPerfGrowthByCountryDataAsync<T>(string countryCode);
}