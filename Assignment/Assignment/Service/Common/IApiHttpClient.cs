using System.Threading.Tasks;

namespace Assignment.Service.Common
{
    public interface IApiHttpClient
    {
        /// <summary>
        /// Gets the asynchronous request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<T> GetAsyncRequest<T>(string url);
    }
}
