using System.Text.Json.Serialization;

namespace SWApi.Net.Entities;

[SWApiEndpoint("planets/")]
public sealed class Planet : IBaseEntity
{
    [JsonConstructor]
    public Planet(
         string climate,
         DateTime created,
         string diameter,
         DateTime edited,
         IEnumerable<string> films,
         string gravity,
         string name,
         string orbitalPeriod,
         string population,
         IEnumerable<string> residents,
         string rotationPeriod,
         string surfaceWater,
         string terrain,
         string url
     )
    {
        Climate = climate;
        Created = created;
        Diameter = diameter;
        Edited = edited;
        Films = films;
        Gravity = gravity;
        Name = name;
        OrbitalPeriod = orbitalPeriod;
        Population = population;
        Residents = residents;
        RotationPeriod = rotationPeriod;
        SurfaceWater = surfaceWater;
        Terrain = terrain;
        Url = url;
    }

    [JsonPropertyName("climate")]
    public string Climate { get; }

    [JsonPropertyName("created")]
    public DateTime Created { get; }

    [JsonPropertyName("diameter")]
    public string Diameter { get; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; }

    [JsonPropertyName("films")]
    public IEnumerable<string> Films { get; }

    [JsonPropertyName("gravity")]
    public string Gravity { get; }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("orbital_period")]
    public string OrbitalPeriod { get; }

    [JsonPropertyName("population")]
    public string Population { get; }

    [JsonPropertyName("residents")]
    public IEnumerable<string> Residents { get; }

    [JsonPropertyName("rotation_period")]
    public string RotationPeriod { get; }

    [JsonPropertyName("surface_water")]
    public string SurfaceWater { get; }

    [JsonPropertyName("terrain")]
    public string Terrain { get; }

    [JsonPropertyName("url")]
    public string Url { get; }
}
