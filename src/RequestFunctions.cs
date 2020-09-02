using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VACEfron.NET
{
    public static class RequestFunctions
    {
        public static string JsonRequest(string endpoint, string jsonObject)
        {
            try
            {
                JObject data = MakeWebRequest(endpoint);

                return data[jsonObject].Value<string>();
            }
            catch
            {
                throw;
            }
        }

        public static JObject JObjectRequest(string endpoint)
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

        public static MemoryStream ImageRequest(string endpoint)
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
            return (MemoryStream) stream.Result;
        }

        public static JObject MakeWebRequest(string endpoint)
        {
            var request = new HttpClient();
            var httpResponseMsg = request.GetAsync($"https://vacefron.nl/api/{endpoint}");
            return (JObject) JsonConvert.DeserializeObject(httpResponseMsg.Result.Content.ReadAsStringAsync().Result);
        }

       
    }
}