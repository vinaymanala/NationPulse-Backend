
namespace Backend.Core.Queries;

public static class PerformanceGrowthQuery
{
    public static FormattableString GetPerfGrowthOfGDPQuery(string countryCode)
    {
        return $@"SELECT * FROM get_perfgrowthgdpds_by_country_code({countryCode});";
    }

    public static FormattableString GetPerfGrowthOfWorkingPopulation(string countryCode)
    {
        return $@"SELECT * FROM get_perfgrowthpopulation_by_country_code({countryCode});";
    }
}