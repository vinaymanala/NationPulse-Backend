
namespace Backend.Infrastructure.Queries;

public static class DashboardQuery
{
    public static int currentYear { get; } = DateTime.Now.Year;
    public static FormattableString GetPopulationChartByCountryQuery()
    {
        return $@"SELECT * FROM perfgrowthpopulationds 
                WHERE 
                year = {currentYear} 
                AND indicator_code LIKE 'POP' 
                ORDER BY value DESC LIMIT 5";
    }

    public static FormattableString GetHealthChartByCountryQuery()
    {
        return $@"SELECT DISTINCT ON (country_code) * FROM healthstatusds 
                WHERE 
                indicator_code LIKE 'CSEM' 
                AND sex_code LIKE '_T' 
                ORDER BY country_code, year DESC, value DESC";
    }

    public static FormattableString GetGDPPerCapitaChartByCountryQuery()
    {
        return $@"WITH ranked_data AS (
                    SELECT *,
                        ROW_NUMBER() OVER (PARTITION BY country_code ORDER BY value DESC) as rn
                    FROM gdppercapitads
                )
                SELECT *
                FROM ranked_data
                WHERE rn = 1 and year LIKE '2025-%'
                ORDER BY value DESC LIMIT 5";
    }
}