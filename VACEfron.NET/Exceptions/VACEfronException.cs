using System.Net;
using System.Text.Json.Serialization;

namespace VACEfron.NET.Exceptions;

public class VACEfronException : Exception
{
    [JsonPropertyName("code")]
    public HttpStatusCode? StatusCode { get; set; }
    
    [JsonPropertyName("message")]
    public new string? Message { get; set; }

    [JsonConstructor]
    public VACEfronException() { }
        
    public VACEfronException(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}