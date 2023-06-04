using SWApi.Net.Entities;
using System.Text.Json.Serialization;

namespace SWApi.Net.Examples;

internal class Program
{
    static async Task Main()
    {
        ///Holocron implements IDisposable to dispose of the data provider!
        using var holocron = new Holocron();


        ///Get all planet entities
        var examplePlanets = await holocron.Get<Planet>();


        ///Get all person entities searched with "Luke"
        var examplePersonSearch = await holocron.Get<Person>("Luke");


        ///Gets the person etntity with the provided Id, returns null if no entity with that id is found
        var exampleGetById = await holocron.GetById<Person>(1);


        ///Using the example class, this will get the new endpoint with it's data, if it exists in the api
        var exampleCustomEndpoint = await holocron.Get<ExampleNewEndpoint>();

    }

    /// <summary>
    /// If perchance a new endpoint becomes available in the api, this is an example of how to create your own path to it!
    /// </summary>
    [SWApiEndpoint("newEndpoint/")]
    public class ExampleNewEndpoint : IBaseEntity
    {
        [JsonConstructor]
        public ExampleNewEndpoint(string someProp)
        {
            SomeProp = someProp;
        }

        [JsonPropertyName("SomeProp")]
        public string SomeProp { get; set; }
    }
}