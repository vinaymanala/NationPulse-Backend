
namespace Backend.Core.Queries;

public static class EconomyQuery
{
    public static FormattableString GetGovernmentDataByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM publicgovernmentyearlyds WHERE countryCode LIKE {countryCode}";
    }

    public static FormattableString GetGDPPerCapitaDataByCountryCodeQuery(string countryCode)
    {
        return $@"SELECT * FROM gdppercapitads WHERE countryCode LIKE {countryCode}";
    }
}