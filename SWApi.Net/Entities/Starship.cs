using System.Text.Json.Serialization;

namespace SWApi.Net.Entities;

[SWApiEndpoint("starships/")]
public sealed class Starship : IBaseEntity
{
    [JsonConstructor]
    public Starship(
       string mGLT,
       string cargoCapacity,
       string consumables,
       string costInCredits,
       DateTime created,
       string crew,
       DateTime edited,
       string hyperdriveRating,
       string length,
       string manufacturer,
       string maxAtmospheringSpeed,
       string model,
       string name,
       string passengers,
       IEnumerable<string> films,
       IEnumerable<string> pilots,
       string starshipClass,
       string url
   )
    {
        MGLT = mGLT;
        CargoCapacity = cargoCapacity;
        Consumables = consumables;
        CostInCredits = costInCredits;
        Created = created;
        Crew = crew;
        Edited = edited;
        HyperdriveRating = hyperdriveRating;
        Length = length;
        Manufacturer = manufacturer;
        MaxAtmospheringSpeed = maxAtmospheringSpeed;
        Model = model;
        Name = name;
        Passengers = passengers;
        Films = films;
        Pilots = pilots;
        StarshipClass = starshipClass;
        Url = url;
    }

    [JsonPropertyName("MGLT")]
    public string MGLT { get; }

    [JsonPropertyName("cargo_capacity")]
    public string CargoCapacity { get; }

    [JsonPropertyName("consumables")]
    public string Consumables { get; }

    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; }

    [JsonPropertyName("created")]
    public DateTime Created { get; }

    [JsonPropertyName("crew")]
    public string Crew { get; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; }

    [JsonPropertyName("hyperdrive_rating")]
    public string HyperdriveRating { get; }

    [JsonPropertyName("length")]
    public string Length { get; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; }

    [JsonPropertyName("max_atmosphering_speed")]
    public string MaxAtmospheringSpeed { get; }

    [JsonPropertyName("model")]
    public string Model { get; }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("passengers")]
    public string Passengers { get; }

    [JsonPropertyName("films")]
    public IEnumerable<string> Films { get; }

    [JsonPropertyName("pilots")]
    public IEnumerable<string> Pilots { get; }

    [JsonPropertyName("starship_class")]
    public string StarshipClass { get; }

    [JsonPropertyName("url")]
    public string Url { get; }
}
