
namespace Backend.Core.Queries;

public static class PerformanceGrowthQuery
{
    public static FormattableString GetPerfGrowthOfGDPQuery(string countryCode)
    {
        return $@"SELECT * FROM perfgrowthgdpds WHERE country_code LIKE {countryCode}";
    }

    public static FormattableString GetPerfGrowthOfWorkingPopulation(string countryCode)
    {
        return $@"SELECT * FROM perfgrowthpopulationds WHERE country_code LIKE {countryCode}";
    }
}