using SWApi.Net.Entities;
using System.Text.Json;

namespace SWApi.Net;

public class Holocron : IHolocron
{
    private readonly IDataProvider _provider;

    public Holocron()
    {
        _provider = new DefaultDataProvider();
    }

    public Holocron(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task<T?> GetById<T>(int id)
        where T : IBaseEntity
    {
        var tType = typeof(T);

        var endpoint = GetEndpoint(tType);

        if (endpoint is null)
        {
            //Not sure what exception to throw in this case
            throw new Exception($"Endpoint could not be extracted for type {tType}");
        }

        var resultJson = await _provider.Request($"{Constants.BaseUrl}{endpoint}{id}");

        if (string.IsNullOrEmpty(resultJson))
        {
            return default;
        }

        var result = JsonSerializer.Deserialize<T>(resultJson);

        return result;
    }

    public async Task<IEnumerable<T>> Get<T>(string? search = null)
        where T : IBaseEntity
    {
        var searchQuery = string.Empty;

        if (!string.IsNullOrEmpty(search))
        {
            searchQuery = $"?search={search}";
        }

        var tType = typeof(T);

        var endpoint = GetEndpoint(tType);

        if (endpoint is null)
        {
            //Not sure what exception to throw in this case
            throw new Exception($"Endpoint could not be extracted for type {tType}");
        }

        var resultJson = await _provider.Request($"{Constants.BaseUrl}{endpoint}{searchQuery}");

        if (string.IsNullOrEmpty(resultJson))
        {
            return Enumerable.Empty<T>();
        }

        var resultHelper = JsonSerializer.Deserialize<Helper<T>>(resultJson)!;

        var result = new List<T>(resultHelper.Count);

        if (resultHelper.Results is null)
        {
            return result;
        }

        result.AddRange(resultHelper.Results);

        while (resultHelper.Next is not null)
        {
            resultJson = await _provider.Request(resultHelper.Next);

            if (resultJson is null)
            {
                break;
            }

            resultHelper = JsonSerializer.Deserialize<Helper<T>>(resultJson);

            if (resultHelper?.Results is null)
            {
                return result;
            }

            result.AddRange(resultHelper.Results);
        }

        return result;
    }

    private string? GetEndpoint(Type type)
    {
        SWApiEndpointAttribute? endpoint = Attribute
            .GetCustomAttribute(
            element: type,
            attributeType: typeof(SWApiEndpointAttribute))
            as SWApiEndpointAttribute;

        string? endpointRes = null;

        if (!string.IsNullOrEmpty(endpoint?.Endpoint))
        {
            endpointRes = endpoint.Endpoint.EndsWith('/')
                ? endpoint.Endpoint
                : $"{endpoint.Endpoint}/";
        }

        return endpointRes;
    }

    public void Dispose()
    {
        _provider.Dispose();
    }
}
