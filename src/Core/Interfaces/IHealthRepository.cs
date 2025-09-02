using Backend.Core.Models.Entities;

namespace Backend.Core.Interfaces;

public interface IHealthRepository
{
    public Task<List<HealthEntity>> GetHealthDataByCountryCodeIdAsync(string countryCode);
}