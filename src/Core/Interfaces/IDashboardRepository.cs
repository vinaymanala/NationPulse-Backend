using Backend.Core.Models.Entities;

namespace Backend.Core.Interfaces;

public interface IDashboardRepository
{
    public Task<List<PerfPopulationGrowthEntity>> GetPopulationDataByNoOfCountriesAsync(short noOfCountries);
    public Task<List<HealthEntity>> GetHealthAllAsync();
    public Task<List<GDPPerCapitaEntity>> GetGdpPerCapitaAllAsync();
}