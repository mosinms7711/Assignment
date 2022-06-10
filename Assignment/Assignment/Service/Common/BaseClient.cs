using System.Net.Http;

namespace Assignment.Service.Common
{
    public class BaseClient
    {
        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns></returns>
        protected HttpClient GetHttpClient()
        {
            HttpClient client;
            
            client = new HttpClient();
           
            return client;
        }
    }
}
