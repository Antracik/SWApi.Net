using SWApi.Net.Entities;
using System.Text.Json.Serialization;

namespace SWApi.Net.Tests;


[SWApiEndpoint("fakeEndpoint")]
internal class EntityWithEndpointAttribute : IBaseEntity
{
    [JsonConstructor]
    public EntityWithEndpointAttribute(int id, string? name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string? Name { get; }
}
