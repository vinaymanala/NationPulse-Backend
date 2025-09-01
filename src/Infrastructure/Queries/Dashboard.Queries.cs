
namespace Backend.Infrastructure.Queries;

public static class DashboardQuery
{
    public static int currentYear { get; } = DateTime.Now.Year;
    public static FormattableString GetPopulationChartByCountryQuery(short noOfCountries)
    {
        return $@"SELECT * FROM get_perfgrowthpopulation_dashboard({currentYear},{noOfCountries});";
    }

    public static FormattableString GetHealthChartByCountryQuery()
    {
        return $@"SELECT * FROM get_healthstatus_dashboard();";
    }

    public static FormattableString GetGDPPerCapitaChartByCountryQuery()
    {
        return $@"WITH ranked_data AS 
                ( SELECT *, ROW_NUMBER() OVER (PARTITION BY country_code ORDER BY value DESC) as rn 
                FROM gdppercapitads ) 
                SELECT * FROM ranked_data 
                WHERE rn = 1 
                and year LIKE '2025-%' 
                ORDER BY value DESC LIMIT 5;";
    }
}