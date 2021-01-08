# VACEfron.NET
 🥤 An API wrapper for VAC Efron's web API.

## Introduction
Install the NuGet package [here](https://www.nuget.org/packages/VACEfron.NET).

Below you can find examples using this wrapper combined with [Discord.NET](https://github.com/discord-net/Discord.Net) in a command context.

You can also visit the [wrapper]() or [API]() documentation (coming soon).

## Examples
Creating an image with custom text. [Result](https://user-images.githubusercontent.com/46462862/90155553-c3007080-dd8b-11ea-98ef-2e483ad03103.png)
```csharp
// All endpoints can be accessed from the VACEfronEndpoint static class.
var stream = VACEfronEndpoint.ChangeMyMind("My text"); 

await Context.Channel.SendFileAsync(stream, "image.png");
```

Creating an image with someone's avatar. [Result](https://user-images.githubusercontent.com/46462862/90156138-681b4900-dd8c-11ea-8ec1-f23b418d65d5.png)
```csharp
var stream = VACEfronEndpoint.Stonks(Context.User.GetAvatarUrl()); 

await Context.Channel.SendFileAsync(stream, "image.png");
```

Creating a rank card image. [Result](https://user-images.githubusercontent.com/46462862/90157660-47ec8980-dd8e-11ea-8c15-2a1a11a29e14.png)
```csharp
var rankCard = new RankCard()
{
    Username = "VAC Efron#0001",
    AvatarUrl = Context.User.GetAvatarUrl(),
    CircleAvatar = true, // Optional circle avatar.
    Level = 5,
    Rank = 1,
    CurrentXp = 1878,
    PreviousLevelXp = 1500,
    NextLevelXp = 2160,
    CustomBackgroundUrl = null, // Optional custom background.
    IsBoosting = false, // Optional server boost icon next to username.
    XpColorHex = null // Optional progress bar color. Defaults to #fcba41.
};

var stream = VACEfronEndpoint.RankCard(rankCard);

await Context.Channel.SendFileAsync(stream, "image.png");
```

## Support
Please join the [Discord server](https://discord.gg/xJ2HRxZ) for any questions or issues.
