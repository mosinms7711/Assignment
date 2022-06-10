using Assignment.Model;
using Assignment.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public class UserDetailRepository : IUserDetailRepository
    {
        readonly IUserDetailService userDetailService;

        public UserDetailRepository(IUserDetailService userDetailService)
        {
            this.userDetailService = userDetailService;
        }

        public async Task<CommonResonseModel> GetAllUserDetails(string url)
        {
            return await userDetailService.GetAllUserDetails(url);
        }
    }
}
