
namespace Backend.Core.Queries;

public static class PopulationQuery
{
    public static FormattableString GetPopulationByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM populationds WHERE country_code LIKE {countryCode}";
    }
}