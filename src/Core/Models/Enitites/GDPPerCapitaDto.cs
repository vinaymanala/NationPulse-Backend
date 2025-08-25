
namespace Backend.Core.Models.Entities;

public class GDPPerCapitaDto
{
    public int Id { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? IndicatorCode { get; set; }

    public string? Indicator { get; set; }

    public string Year { get; set; }

    public decimal Value { get; set; }
}