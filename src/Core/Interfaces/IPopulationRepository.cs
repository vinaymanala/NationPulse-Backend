using Backend.Core.Models.Entities;

namespace Backend.Core.Interfaces;

public interface IPopulationRepository
{
    public Task<List<PopulationEntity>> GetPopulationDataByCountryCodeIdAsync(string countryCode);
}