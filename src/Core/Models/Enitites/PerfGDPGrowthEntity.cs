

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Core.Models.Entities;

public class PerfGDPGrowthEntity
{
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("country_code")]
    public string? CountryCode { get; set; }

    [NotNull]
    [Column("country_name")]
    public string? CountryName { get; set; }

    [NotNull]
    [Column("indicator_code")]
    public string? IndicatorCode { get; set; }

    [NotNull]
    [Column("indicator")]
    public string? Indicator { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("value")]
    public decimal Value { get; set; }
}
