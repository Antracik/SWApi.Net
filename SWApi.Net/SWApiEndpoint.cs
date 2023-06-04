namespace SWApi.Net;

[AttributeUsage(AttributeTargets.Class)]
public class SWApiEndpointAttribute : Attribute
{
    public string Endpoint { get; init; }

    public SWApiEndpointAttribute(string endpoint)
    {
        Endpoint = endpoint;
    }
}
