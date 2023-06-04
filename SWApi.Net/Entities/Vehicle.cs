using System.Text.Json.Serialization;

namespace SWApi.Net.Entities;

[SWApiEndpoint("vehicles/")]
public sealed class Vehicle : IBaseEntity
{
    [JsonConstructor]
    public Vehicle(
        string cargoCapacity,
        string consumables,
        string costInCredits,
        DateTime created,
        string crew,
        DateTime edited,
        string length,
        string manufacturer,
        string maxAtmospheringSpeed,
        string model,
        string name,
        string passengers,
        IEnumerable<string> pilots,
        IEnumerable<string> films,
        string url,
        string vehicleClass
    )
    {
        CargoCapacity = cargoCapacity;
        Consumables = consumables;
        CostInCredits = costInCredits;
        Created = created;
        Crew = crew;
        Edited = edited;
        Length = length;
        Manufacturer = manufacturer;
        MaxAtmospheringSpeed = maxAtmospheringSpeed;
        Model = model;
        Name = name;
        Passengers = passengers;
        Pilots = pilots;
        Films = films;
        Url = url;
        VehicleClass = vehicleClass;
    }

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

    [JsonPropertyName("pilots")]
    public IEnumerable<string> Pilots { get; }

    [JsonPropertyName("films")]
    public IEnumerable<string> Films { get; }

    [JsonPropertyName("url")]
    public string Url { get; }

    [JsonPropertyName("vehicle_class")]
    public string VehicleClass { get; }
}
