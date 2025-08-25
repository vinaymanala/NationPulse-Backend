
namespace Backend.Core.Queries;

public static class HealthQuery
{
    public static FormattableString GetHealthStatusByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM healthstatusds WHERE country_code LIKE {countryCode}";
    }
}