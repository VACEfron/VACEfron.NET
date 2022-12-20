# VACEfron.NET 🌯
An asyncronous API wrapper for [VAC Efron's API](https://vacefron.nl/api).

## Installation
[<img src="https://img.shields.io/nuget/v/VACEfron.NET"></img>](https://www.nuget.org/packages/VACEfron.NET)

## Example

Calling the "ejected" endpoint and writing the image to a file. [Result](https://user-images.githubusercontent.com/46462862/208753419-9352cf3f-6780-454d-aa00-0d87e9a39002.png)
```csharp
using VACEfron.NET;
using VACEfron.NET.Enums;
using VACEfron.NET.Exceptions;

try
{
    var client = new VACEfronClient();

    var stream = await client.EjectedAsync(name: "VAC Efron", isImpostor: true, crewmateColor: CrewmateColor.Pink);

    await using var fs = File.Create("image.png");
    stream.CopyTo(fs);
}
catch (VACEfronException e)
{
    Console.WriteLine(e.StatusCode);
    Console.WriteLine(e.Message);
}
```