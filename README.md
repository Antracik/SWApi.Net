# SWApi.Net

A very simple .NET wrapper for [SWAPI](https://swapi.dev/) - The Star Wars API

Recommended to first familiarise yourself with the SWAPI documentation.

NOTE: Id's of the retrieved entities are not available in the entity classes yet

### Installing

To install, simply use the nuget package manager and search for SWApi.Net

 or add manually:
 ``` dotnet add package SWApi.Net ```
 
 or directly into your csproj:
 ```<PackageReference Include="SWApi.Net" Version="1.0.1" />```
 
 Example usage:
```csharp
using var holocron = new Holocron();

//Will return all people
var people = holocron.Get<Person>();

//Will return all people matching the search term, if none match, then an empty list is returned
var peopleWithSearchTerm = holocron.Get<Person>("Luke");

//Will return the planet matching the id, if no match is found, returns null
var planet = holocron.GetById<Planet>(12);
```

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details
