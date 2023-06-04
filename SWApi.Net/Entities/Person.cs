using System.Text.Json.Serialization;

namespace SWApi.Net.Entities;

[SWApiEndpoint("people/")]
public sealed class Person : IBaseEntity
{
    [JsonConstructor]
    public Person(
        string name,
        string height,
        string mass,
        string hairColor,
        string skinColor,
        string eyeColor,
        string birthYear,
        string gender,
        string homeworld,
        IEnumerable<string> films,
        IEnumerable<string> species,
        IEnumerable<string> vehicles,
        IEnumerable<string> starships,
        DateTime created,
        DateTime edited,
        string url
    )
    {
        Name = name;
        Height = height;
        Mass = mass;
        HairColor = hairColor;
        SkinColor = skinColor;
        EyeColor = eyeColor;
        BirthYear = birthYear;
        Gender = gender;
        Homeworld = homeworld;
        Films = films;
        Species = species;
        Vehicles = vehicles;
        Starships = starships;
        Created = created;
        Edited = edited;
        Url = url;
    }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("height")]
    public string Height { get; }

    [JsonPropertyName("mass")]
    public string Mass { get; }

    [JsonPropertyName("hair_color")]
    public string HairColor { get; }

    [JsonPropertyName("skin_color")]
    public string SkinColor { get; }

    [JsonPropertyName("eye_color")]
    public string EyeColor { get; }

    [JsonPropertyName("birth_year")]
    public string BirthYear { get; }

    [JsonPropertyName("gender")]
    public string Gender { get; }

    [JsonPropertyName("homeworld")]
    public string Homeworld { get; }

    [JsonPropertyName("films")]
    public IEnumerable<string> Films { get; }

    [JsonPropertyName("species")]
    public IEnumerable<object> Species { get; }

    [JsonPropertyName("vehicles")]
    public IEnumerable<string> Vehicles { get; }

    [JsonPropertyName("starships")]
    public IEnumerable<string> Starships { get; }

    [JsonPropertyName("created")]
    public DateTime Created { get; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; }

    [JsonPropertyName("url")]
    public string Url { get; }
}
