using SWApi.Net.Entities;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("SWApi.Net.Tests")]
namespace SWApi.Net;

internal sealed class Helper<T> where T : IBaseEntity
{
    [JsonConstructor]
    public Helper(
        int count,
        string? next,
        IEnumerable<T>? results)
    {
        Count = count;
        Next = next;
        Results = results;
    }

    [JsonPropertyName("count")]
    public int Count { get; }

    [JsonPropertyName("next")]
    public string? Next { get; }

    [JsonPropertyName("results")]
    public IEnumerable<T>? Results { get; }
}
