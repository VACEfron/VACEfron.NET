using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

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
            catch { throw; }            
        }

        public static JObject JObjectRequest(string endpoint)
        {
            try
            {
                return MakeWebRequest(endpoint);
            }
            catch { throw; }
        }

        public static MemoryStream ImageRequest(string endpoint)
        {
            try
            {
                using var httpClient = new HttpClient();
                var stream = httpClient.GetStreamAsync($"https://vacefron.nl/api/{endpoint}");
                stream.Wait();
                return (MemoryStream) stream.Result;
            }
            catch(AggregateException exception)
            {
                if (exception.InnerException.InnerException /* Inner inner exception should be WebException */ is WebException webException)
                {
                    using var reader = new StreamReader(webException.Response.GetResponseStream());
                    var error = (JObject)JsonConvert.DeserializeObject(reader.ReadToEnd());
                    throw new Exception($"Status {error["code"].Value<int>()}: {error["message"].Value<string>()}");
                } else throw new Exception("Error ocurred while trying to get MemoryStream.", exception.InnerException);
            }
        }

		public static JObject MakeWebRequest(string endpoint)
        {
            var request = new HttpClient();
            var stream = request.GetStreamAsync($"https://vacefron.nl/api/{endpoint}");
            stream.Wait();
            var responseString = new StreamReader(stream.Result).ReadToEnd();

            return (JObject)JsonConvert.DeserializeObject(responseString);
        }

        
    }
}
