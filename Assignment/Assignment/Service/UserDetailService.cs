using Assignment.Model;
using Assignment.Service.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service
{
    public class UserDetailService : IUserDetailService
    {
        readonly IApiHttpClient httpClient;
        public UserDetailService():base()
        {
            httpClient = new ApiHttpClient();
        }

        public async Task<CommonResonseModel> GetAllUserDetails(string url)
        {
            var result = await this.httpClient.GetAsyncRequest<CommonResonseModel>(url);

            return result;
        }
    }
}
