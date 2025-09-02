
using AutoMapper;

using Backend.Core.Models.Entities;

namespace Backend.ApiHost.Setup;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PopulationEntity, PopulationDto>();
        CreateMap<HealthEntity, HealthDto>();
        CreateMap<GDPPerCapitaEntity, GDPPerCapitaDto>();
        CreateMap<GovernmentDataEntity, GovernmentDataDto>();
        CreateMap<PerfGDPGrowthEntity, PerfGDPGrowthDto>();
        CreateMap<PerfPopulationGrowthEntity, PerfPopulationGrowthDto>();
    }
}