using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Interfaces;

public interface IHealthService
{
    public Task<ServiceReponse<List<T>>> GetHealthDataByCountryCodeAsync<T>(string countryCode);
}