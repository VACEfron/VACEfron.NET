using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VACEfron.NET
{
    internal static class RequestFunctions
    {
        internal static string JsonRequest(string endpoint, string key)
        {
            try
            {
                JObject data = MakeWebRequest(endpoint);

                return data[key].Value<string>();
            }
            catch
            {
                throw;
            }
        }

        internal static JObject JObjectRequest(string endpoint)
        {
            try
            {
                return MakeWebRequest(endpoint);
            }
            catch
            {
                throw;
            }
        }

        internal static MemoryStream ImageRequest(string endpoint)
        {
            using var httpClient = new HttpClient();
            var getRequest = httpClient.GetAsync("https://vacefron.nl/api/" + endpoint, HttpCompletionOption.ResponseContentRead);
            var responseMessage = getRequest.Result;
            if (!responseMessage.IsSuccessStatusCode)
            {
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                var error = (JObject) JsonConvert.DeserializeObject(responseString);
                throw new Exception($"Status {error["code"].Value<int>()}: {error["message"].Value<string>()}");
            }

            var stream = responseMessage.Content.ReadAsStreamAsync();
            return (MemoryStream)stream.Result;
        }

        internal static JObject MakeWebRequest(string endpoint)
        {
            var httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync($"https://vacefron.nl/api/{endpoint}");
            return (JObject)JsonConvert.DeserializeObject(responseMessage.Result.Content.ReadAsStringAsync().Result);
        }
    }
}
