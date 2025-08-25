

namespace Backend.Core.Models.Entities;

public class HealthDto
{
    public int Id { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? IndicatorCode { get; set; }

    public string? Indicator { get; set; }

    public string? SexCode { get; set; }

    public string? SexName { get; set; }

    public string? Cause { get; set; }

    public string? UnitRange { get; set; }

    public int Year { get; set; }

    public decimal Value { get; set; }
}