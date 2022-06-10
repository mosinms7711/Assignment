using Assignment.Model;
using System.Threading.Tasks;

namespace Assignment.Service
{
    public interface IUserDetailService
    {
        /// <summary>
        /// Gets all user details.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<CommonResonseModel> GetAllUserDetails(string url);
    }
}
