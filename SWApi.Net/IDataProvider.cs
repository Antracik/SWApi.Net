namespace SWApi.Net;

/// <summary>
/// Used by the wrapper to initiate requests, 
/// by default, if no provider is given, a default one using HttpClient is used
/// </summary>
public interface IDataProvider : IDisposable
{
    public Task<string?> Request(string url);
}