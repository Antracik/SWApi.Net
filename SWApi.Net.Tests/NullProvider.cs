namespace SWApi.Net.Tests;

internal class NullProvider : IDataProvider
{
    public void Dispose()
    {
        
    }

    public Task<string?> Request(string url)
    {
        return Task.FromResult<string?>(null);
    }
}
