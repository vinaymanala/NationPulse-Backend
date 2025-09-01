
namespace Backend.Core.Queries;

public static class HealthQuery
{
    public static FormattableString GetHealthStatusByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM get_healthstatus_by_country_code({countryCode});";
    }
}