
using AutoMapper;

using Backend.Core.Interfaces;
using Backend.Core.Models.Entities;
using Backend.Core.Utils;

namespace Backend.Core.Services;

public class HealthService : IHealthService
{
    private readonly IMapper _mapper;
    private readonly IHealthRepository _repository;
    public HealthService(IMapper mapper, IHealthRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ServiceReponse<List<T>>> GetHealthDataByCountryCodeAsync<T>(string countryCode)
    {
        var isSuccess = default(bool);
        var data = new List<HealthEntity>();
        try
        {
            data = await _repository.GetHealthDataByCountryCodeIdAsync(countryCode);
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
}