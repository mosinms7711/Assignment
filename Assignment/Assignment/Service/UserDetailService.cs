using Assignment.Model;
using Assignment.Service.Common;
using System.Threading.Tasks;

namespace Assignment.Service
{
    /// <seealso cref="Assignment.Service.IUserDetailService" />
    public class UserDetailService : IUserDetailService
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        readonly IApiHttpClient httpClient;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailService"/> class.
        /// </summary>
        public UserDetailService():base()
        {
            httpClient = new ApiHttpClient();
        }

        /// <summary>
        /// Gets all user details.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<CommonResonseModel> GetAllUserDetails(string url)
        {
            var result = await this.httpClient.GetAsyncRequest<CommonResonseModel>(url);

            return result;
        }
    }
}
