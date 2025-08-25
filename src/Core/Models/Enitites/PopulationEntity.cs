

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Core.Models.Entities;

public class PopulationEntity
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
    [Column("age")]
    public string? Age { get; set; }

    [NotNull]
    [Column("indicator_code")]
    public string? IndicatorCode { get; set; }

    [NotNull]
    [Column("indicator")]
    public string? Indicator { get; set; }

    [NotNull]
    [Column("sex_code")]
    public string? SexCode { get; set; }

    [NotNull]
    [Column("sex_name")]
    public string? SexName { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("value")]
    public decimal Value { get; set; }
}
