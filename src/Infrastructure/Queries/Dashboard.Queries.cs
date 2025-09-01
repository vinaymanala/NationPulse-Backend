
namespace Backend.Infrastructure.Queries;

public static class DashboardQuery
{
    public static int currentYear { get; } = DateTime.Now.Year;
    public static FormattableString GetPopulationChartByCountryQuery()
    {
        return $@"SELECT * FROM get_perfgrowthpopulation_dashboard({currentYear});";
    }

    public static FormattableString GetHealthChartByCountryQuery()
    {
        return $@"SELECT * FROM get_healthstatus_dashboard();";
    }

    public static FormattableString GetGDPPerCapitaChartByCountryQuery()
    {
        return $@"SELECT * FROM get_gdppercapita_dashboard();";
    }
}