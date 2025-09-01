
namespace Backend.Core.Queries;

public static class EconomyQuery
{
    public static FormattableString GetGovernmentDataByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM get_publicgovernmentyearly_by_country_code({countryCode});";
    }

    public static FormattableString GetGDPPerCapitaDataByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM get_gdppercapita_by_country_code({countryCode});";
    }
}