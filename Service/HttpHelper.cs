using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Service
{
    public class HttpHelper
    {
        public async Task<T> Get<T>(string url)
        {
            using(var htttpClient = new HttpClient())
            {
               using(HttpResponseMessage response = await htttpClient.GetAsync(url))
               {
                   if(response.IsSuccessStatusCode)
                   {
                      var responseString =  response.Content.ReadAsStringAsync().Result;     
                      var responseObj =  JsonConvert.DeserializeObject<T>(responseString);
                      return responseObj;
                   }
               }
            }
            return default(T);
        }
    }
}
