
using AutoMapper;

using Backend.Core.Interfaces;
using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Services;

public class EconomyService : IEconomyService
{
    private readonly IMapper _mapper;
    private readonly IEconomyRepository _repository;
    public EconomyService(IMapper mapper, IEconomyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ServiceReponse<List<T>>> GetGovernmentDataByCountryCodeIdAsync<T>(string countryCode)
    {
        var isSuccess = default(bool);
        var data = new List<GovernmentDataEntity>();
        try
        {
            data = await _repository.GetGovernmentDataByCountryCodeIdAsync(countryCode);
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching government public data", ex);
        }
        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }

    public async Task<ServiceReponse<List<T>>> GetGDPPerCapitaDataByCountryCodeIdAsync<T>(string countryCode)
    {
        var isSuccess = default(bool);
        var data = new List<GDPPerCapitaEntity>();
        try
        {
            data = await _repository.GetGDPPerCapitaDataByCountryCodeIdAsync(countryCode);
            isSuccess = true;
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
            throw new Exception("Error fetching gdp per capita data", ex);
        }
        var mappedData = _mapper.Map<List<T>>(data);

        return new ServiceReponse<List<T>>
        {
            data = mappedData,
            isSuccess = isSuccess,
        };
    }
}