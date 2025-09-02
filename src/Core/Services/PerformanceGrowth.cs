
using AutoMapper;

using Backend.Core.Interfaces;
using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Services;

public class PerformanceGrowthService : IPerformanceService
{
    private readonly IMapper _mapper;
    private readonly IPerformanceRepository _repository;
    public PerformanceGrowthService(IMapper mapper, IPerformanceRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ServiceReponse<List<T>>> GetGDPPerfGrowthByCountryDataAsync<T>(string countryCode)
    {
        var isSuccess = default(bool);
        var data = new List<PerfGDPGrowthEntity>();
        try
        {
            data = await _repository.GetGDPPerfGrowthByCountryIdAsync(countryCode);
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching performance gdp per capita growth data", ex);
        }
        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }

    public async Task<ServiceReponse<List<T>>> GetPopulationPerfGrowthByCountryDataAsync<T>(string countryCode)
    {
        var isSuccess = default(bool);
        var data = new List<PerfPopulationGrowthEntity>();
        try
        {
            data = await _repository.GetPopulationPerfGrowthByCountryIdAsync(countryCode);
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching performance population growth data", ex);
        }
        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }
}