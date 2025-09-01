
namespace Backend.Core.Queries;

public static class PopulationQuery
{
    public static FormattableString GetPopulationByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM get_population_by_country_code({countryCode});";
    }
}