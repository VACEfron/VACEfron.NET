using System.Text.Json;
using System.Web;
using VACEfron.NET.Exceptions;

namespace VACEfron.NET.Services;

internal class RequestService
{
    private readonly HttpClient _httpClient = new() { BaseAddress = new("https://vacefron.nl/api/") };

    internal async Task<Stream> GetStreamAsync(string endpoint, Dictionary<string, string?> parameters)
    {
        var response = await _httpClient.GetAsync(endpoint + GenerateQueryParameters(parameters)).ConfigureAwait(false);
        Console.WriteLine(endpoint + GenerateQueryParameters(parameters));
        if (response.IsSuccessStatusCode) 
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        
        var exception = await JsonSerializer.DeserializeAsync<VACEfronException>(await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = false }).ConfigureAwait(false);
        throw exception!;
    }

    private string GenerateQueryParameters(Dictionary<string, string?> parameters)
        => "?" + string.Join("&", parameters
            .Where(x => !string.IsNullOrEmpty(x.Value))
            .Select(x => $"{x.Key}={HttpUtility.UrlEncode(x.Value)?.Replace("%7c", "|")}"));
}