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
                using WebClient webClient = new WebClient();
                byte[] byteArray = webClient.DownloadData($"https://vacefron.nl/api/{endpoint}");

                return new MemoryStream(byteArray);
            }
            catch(WebException exception)
            {                
                using var reader = new StreamReader(exception.Response.GetResponseStream());
                JObject error = (JObject)JsonConvert.DeserializeObject(reader.ReadToEnd());

                throw new Exception($"Status {error["code"].Value<int>()}: {error["message"].Value<string>()}");
            }
        }

        public static JObject MakeWebRequest(string endpoint)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://vacefron.nl/api/{endpoint}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return (JObject)JsonConvert.DeserializeObject(responseString);
        }
    }
}
