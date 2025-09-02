
using AutoMapper;

using Backend.Core.Interfaces;
using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Services;

public class DashboardService : IDashboardService
{
    private readonly IMapper _mapper;
    private readonly IDashboardRepository _repository;
    public DashboardService(IMapper mapper, IDashboardRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ServiceReponse<List<T>>> GetPopulationDataAsync<T>(short noOfCountries)
    {
        var isSuccess = default(bool);
        var data = new List<PerfPopulationGrowthEntity>();
        try
        {
            data = await _repository.GetPopulationDataByNoOfCountriesAsync(noOfCountries);
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching population data", ex);
        }
        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }

    public async Task<ServiceReponse<List<T>>> GetHealthDataAsync<T>()
    {
        var isSuccess = default(bool);
        var data = new List<HealthEntity>();
        try
        {
            data = await _repository.GetHealthAllAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching health data:", ex);
        }

        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }


    public async Task<ServiceReponse<List<T>>> GetGdpPerCapitaDataAsync<T>()
    {
        var isSuccess = default(bool);
        var data = new List<GDPPerCapitaEntity>();
        try
        {
            data = await _repository.GetGdpPerCapitaAllAsync();
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching gdp per capita data :", ex);
        }

        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }

}
