using Newtonsoft.Json;
using System.Net.Http;

namespace HandsOnTestGoDigital.Infraestructure
{
    public class RequestMovie<T> where T : class
    {
        private const string APIKEY = "848fcb8e4c9b8d8a0e51fcc8b37a4540";
        private const string URL = "https://api.themoviedb.org/3/";

        public T HttpGet(string requestName, string parameters = "")
        {
            T data = null;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync($"{URL}{requestName}?api_key={APIKEY}{parameters}").ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responsesString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    data = JsonConvert.DeserializeObject<T>(responsesString);
                }
            };
            return data;
        }
    }
}
