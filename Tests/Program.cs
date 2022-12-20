using VACEfron.NET;
using VACEfron.NET.Enums;
using VACEfron.NET.Exceptions;

var client = new VACEfronClient();

//var stream = await client.AdiosAsync("https://cdn.discordapp.com/avatars/326260487220363275/b6ac0138bc2bd293ae9b075d2a51578c.png?size=1024");
try
{
    //var stream = await client.ICanMilkYouAsync("https://cdn.discordapp.com/avatars/326260487220363275/b6ac0138bc2bd293ae9b075d2a51578c.png?size=1024");
    var stream = await client.RankCardAsync("VAC Efron#0001", "https://cdn.discordapp.com/avatars/326260487220363275/b6ac0138bc2bd293ae9b075d2a51578c.png?size=1024",
        10, 0, 23, 10, 5, "",
        "ff0000", "00ff00", true, new[] {Badge.ServerOwner, Badge.Balance, Badge.Developer, Badge.Staff});
    await using var fs = File.Create("image.png");
    stream.CopyTo(fs);
}
catch (VACEfronException e)
{
    Console.WriteLine(e.StatusCode);
    Console.WriteLine(e.Message);
}