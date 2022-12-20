using VACEfron.NET.Enums;
using VACEfron.NET.Services;

namespace VACEfron.NET;

public class VACEfronClient
{
    private readonly RequestService _requestService = new();

    public async Task<Stream> AdiosAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("adios", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> BatmanSlapAsync(string batmanText, string robinText, string batmanAvatarUrl, string robinAvatarUrl)
        => await _requestService.GetStreamAsync("batmanslap", 
            new() {{"text1", robinText}, {"text2", batmanText}, {"batman", batmanAvatarUrl}, {"robin", robinAvatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> CarReverseAsync(string text)
        => await _requestService.GetStreamAsync("carreverse", new() {{"text", text}}).ConfigureAwait(false);
    
    public async Task<Stream> ChangeMyMindAsync(string text)
        => await _requestService.GetStreamAsync("changemymind", new() {{"text", text}}).ConfigureAwait(false);
    
    public async Task<Stream> DistractedBoyfriendAsync(string boyfriendAvatarUrl, string girlfriendAvatarUrl, string womanAvatarUrl)
        => await _requestService.GetStreamAsync("distractedbf", 
            new() {{"boyfriend", boyfriendAvatarUrl}, {"girlfriend", girlfriendAvatarUrl}, {"woman", womanAvatarUrl}}).ConfigureAwait(false);
 
    public async Task<Stream> DockOfShameAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("dockofshame", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> DripAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("drip", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> EjectedAsync(string name, bool isImpostor, CrewmateColor crewmateColor)
        => await _requestService.GetStreamAsync("ejected", 
            new() {{"name", name}, {"impostor", isImpostor.ToString()}, {"crewmate", crewmateColor.ToString()}}).ConfigureAwait(false);
    
    public async Task<Stream> EmergencyMeetingAsync(string text)
        => await _requestService.GetStreamAsync("emergencymeeting", new() {{"text", text}}).ConfigureAwait(false);
    
    public async Task<Stream> FirstTimeAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("firsttime", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> GraveAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("grave", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> IAmSpeedAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("iamspeed", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> ICanMilkYouAsync(string markiplierAvatarUrl, string? cowAvatarUrl = null)
        => await _requestService.GetStreamAsync("icanmilkyou", new() {{"user1", markiplierAvatarUrl}, {"user2", cowAvatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> HeavenAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("heaven", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> NpcAsync(string text1, string text2)
        => await _requestService.GetStreamAsync("npc", new() {{"text1", text1}, {"text2", text2}}).ConfigureAwait(false);
    
    public async Task<Stream> PeepoSignAsync(string text)
        => await _requestService.GetStreamAsync("peeposign", new() {{"text", text}}).ConfigureAwait(false);

    public async Task<Stream> RankCardAsync(string username, string avatarUrl, int currentXp, int previousLevelXp, int nextLevelXp, int? level = null, int? rank = null,
        string? customBgUrlOrHex = null, string? textShadowColorHex = null, string? xpColorHex = null, bool? circleAvatar = null, Badge[]? badges = null)
    {
        return await _requestService.GetStreamAsync("rankcard", new()
        {
            {"username", username},
            {"avatar", avatarUrl},
            {"currentXp", currentXp.ToString()},
            {"previousLevelXp", previousLevelXp.ToString()},
            {"nextLevelXp", nextLevelXp.ToString()},
            {"level", level?.ToString()},
            {"rank", rank?.ToString()},
            {"customBg", customBgUrlOrHex},
            {"textShadowColor", textShadowColorHex},
            {"xpColor", xpColorHex},
            {"circleAvatar", circleAvatar?.ToString()},
            {"badges", badges?.Any() is true ? string.Join("|", badges) : null}
        }).ConfigureAwait(false);
    }

    public async Task<Stream> StonksAsync(string avatarUrl, bool notStonks = false)
        => await _requestService.GetStreamAsync("stonks", new() {{"user", avatarUrl}, {"notStonks", notStonks.ToString()}}).ConfigureAwait(false);
    
    public async Task<Stream> TableflipAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("tableflip", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> WaterAsync(string text)
        => await _requestService.GetStreamAsync("water", new() {{"text", text}}).ConfigureAwait(false);
    
    public async Task<Stream> WideAsync(string imageUrl)
        => await _requestService.GetStreamAsync("wide", new() {{"image", imageUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> WolverineAsync(string avatarUrl)
        => await _requestService.GetStreamAsync("wolverine", new() {{"user", avatarUrl}}).ConfigureAwait(false);
    
    public async Task<Stream> WomanYellingAtCat(string womanAvatarUrl, string catAvatarUrl)
        => await _requestService.GetStreamAsync("womanyellingatcat", new() {{"woman", womanAvatarUrl}, {"cat", catAvatarUrl}}).ConfigureAwait(false);
}
