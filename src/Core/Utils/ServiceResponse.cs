
namespace Backend.Core.Utils;

public class ServiceReponse<T>
{
    public bool isSuccess { get; set; }
    public string? message { get; set; }
    public T? data { get; set; }
}

