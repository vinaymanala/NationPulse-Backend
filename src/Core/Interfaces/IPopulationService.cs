using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Interfaces;

public interface IPopulationService
{
    public Task<ServiceReponse<List<T>>> GetPopulationDataByCountryCodeAsync<T>(string countryCode);
}