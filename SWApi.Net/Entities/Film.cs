using System.Text.Json.Serialization;

namespace SWApi.Net.Entities;

[SWApiEndpoint("films/")]
public sealed class Film : IBaseEntity
{
    [JsonConstructor]
    public Film(
        IEnumerable<string> characters,
        DateTime created,
        string director,
        DateTime edited,
        int episodeId,
        string openingCrawl,
        IEnumerable<string> planets,
        string producer,
        string releaseDate,
        IEnumerable<string> species,
        IEnumerable<string> starships,
        string title,
        string url,
        IEnumerable<string> vehicles
    )
    {
        Characters = characters;
        Created = created;
        Director = director;
        Edited = edited;
        EpisodeId = episodeId;
        OpeningCrawl = openingCrawl;
        Planets = planets;
        Producer = producer;
        ReleaseDate = releaseDate;
        Species = species;
        Starships = starships;
        Title = title;
        Url = url;
        Vehicles = vehicles;
    }

    [JsonPropertyName("characters")]
    public IEnumerable<string> Characters { get; }

    [JsonPropertyName("created")]
    public DateTime Created { get; }

    [JsonPropertyName("director")]
    public string Director { get; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; }

    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; }

    [JsonPropertyName("opening_crawl")]
    public string OpeningCrawl { get; }

    [JsonPropertyName("planets")]
    public IEnumerable<string> Planets { get; }

    [JsonPropertyName("producer")]
    public string Producer { get; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; }

    [JsonPropertyName("species")]
    public IEnumerable<string> Species { get; }

    [JsonPropertyName("starships")]
    public IEnumerable<string> Starships { get; }

    [JsonPropertyName("title")]
    public string Title { get; }

    [JsonPropertyName("url")]
    public string Url { get; }

    [JsonPropertyName("vehicles")]
    public IEnumerable<string> Vehicles { get; }
}
