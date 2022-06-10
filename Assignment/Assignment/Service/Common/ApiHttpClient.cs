using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Assignment.Service.Common
{
    /// <seealso cref="Assignment.Service.Common.BaseClient" />
    /// <seealso cref="Assignment.Service.Common.IApiHttpClient" />
    public class ApiHttpClient : BaseClient, IApiHttpClient
    {
        /// <summary>
        /// Gets the asynchronous request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
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
