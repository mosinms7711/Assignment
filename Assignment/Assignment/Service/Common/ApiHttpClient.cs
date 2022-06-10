using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Common
{
    public class ApiHttpClient : BaseClient, IApiHttpClient
    {
        public async Task<T> GetAsyncRequest<T>(string url)
        {
            var returnResult = default(T);
            var client = GetHttpClient();

            var responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                returnResult = JsonConvert.DeserializeObject<T>(jsonString);
            }

            return returnResult;
        }
    }
}
