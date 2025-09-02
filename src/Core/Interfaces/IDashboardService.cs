
using Backend.Core.Utils;

namespace Backend.Core.Interfaces;

public interface IDashboardService
{
    public Task<ServiceReponse<List<T>>> GetPopulationDataAsync<T>(short noOfCountries);
    public Task<ServiceReponse<List<T>>> GetHealthDataAsync<T>();
    public Task<ServiceReponse<List<T>>> GetGdpPerCapitaDataAsync<T>();
}