
using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure;


public partial class AppDbContext : DbContext
{
    [NotNull]
    public string? Name { get; set; }
}