using Assignment.Model;
using Assignment.Service;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    /// <seealso cref="Assignment.Repository.IUserDetailRepository" />
    public class UserDetailRepository : IUserDetailRepository
    {
        /// <summary>
        /// The user detail service
        /// </summary>
        readonly IUserDetailService userDetailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailRepository"/> class.
        /// </summary>
        /// <param name="userDetailService">The user detail service.</param>
        public UserDetailRepository(IUserDetailService userDetailService)
        {
            this.userDetailService = userDetailService;
        }

        /// <summary>
        /// Gets all user details.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<CommonResonseModel> GetAllUserDetails(string url)
        {
            return await userDetailService.GetAllUserDetails(url);
        }
    }
}
