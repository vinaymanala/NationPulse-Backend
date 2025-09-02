using Backend.Core.Models.Entities;

namespace Backend.Core.Interfaces;

public interface IPerformanceRepository
{
    public Task<List<PerfGDPGrowthEntity>> GetGDPPerfGrowthByCountryIdAsync(string countryCode);
    public Task<List<PerfPopulationGrowthEntity>> GetPopulationPerfGrowthByCountryIdAsync(string countryCode);
}