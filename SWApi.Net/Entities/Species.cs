using System.Text.Json.Serialization;

namespace SWApi.Net.Entities;

[SWApiEndpoint("species/")]
public sealed class Species : IBaseEntity
{
    [JsonConstructor]
    public Species(
        string averageHeight,
        string averageLifespan,
        string classification,
        DateTime created,
        string designation,
        DateTime edited,
        string eyeColors,
        string hairColors,
        string homeworld,
        string language,
        string name,
        IEnumerable<string> people,
        IEnumerable<string> films,
        string skinColors,
        string url
    )
    {
        AverageHeight = averageHeight;
        AverageLifespan = averageLifespan;
        Classification = classification;
        Created = created;
        Designation = designation;
        Edited = edited;
        EyeColors = eyeColors;
        HairColors = hairColors;
        Homeworld = homeworld;
        Language = language;
        Name = name;
        People = people;
        Films = films;
        SkinColors = skinColors;
        Url = url;
    }

    [JsonPropertyName("average_height")]
    public string AverageHeight { get; }

    [JsonPropertyName("average_lifespan")]
    public string AverageLifespan { get; }

    [JsonPropertyName("classification")]
    public string Classification { get; }

    [JsonPropertyName("created")]
    public DateTime Created { get; }

    [JsonPropertyName("designation")]
    public string Designation { get; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; }

    [JsonPropertyName("eye_colors")]
    public string EyeColors { get; }

    [JsonPropertyName("hair_colors")]
    public string HairColors { get; }

    [JsonPropertyName("homeworld")]
    public string Homeworld { get; }

    [JsonPropertyName("language")]
    public string Language { get; }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("people")]
    public IEnumerable<string> People { get; }

    [JsonPropertyName("films")]
    public IEnumerable<string> Films { get; }

    [JsonPropertyName("skin_colors")]
    public string SkinColors { get; }

    [JsonPropertyName("url")]
    public string Url { get; }
}
