using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SWApi.Net.Tests")]
namespace SWApi.Net;

internal sealed class DefaultDataProvider : IDataProvider
{
    private HttpClient _client { get; set; } = new HttpClient();
    private bool _isDisposed;

    public async Task<string?> Request(string url)
    {
        if (_isDisposed)
        {
            _client = new HttpClient();
            _isDisposed = false;
        }

        string? result;
        try
        {
            result = await _client.GetStringAsync(url);
        }
        catch
        {
            return null;
        }

        return result;
    }

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _client.Dispose();
            _isDisposed = true;
        }
    }
}

