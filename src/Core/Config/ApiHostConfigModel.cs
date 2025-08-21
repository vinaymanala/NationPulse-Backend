
using System.Diagnostics.CodeAnalysis;

namespace Backend.Core.Config;

public class Database
{
    [NotNull]
    public string? ConnectionString { get; init; }

    public string ResolveConnectionString()
    {
        if (RunTimeEnv.IsDevelopment)
        {
            return ConnectionString;
        }
        return ConnectionString.Replace("127.0.0.1", "postgres");
    }
}

public class ApiHostConfig
{
    [NotNull]
    public Database? Database { get; init; }
}