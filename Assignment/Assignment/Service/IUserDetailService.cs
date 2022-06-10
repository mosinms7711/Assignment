using Assignment.Model;
using System.IO;
using System.Threading.Tasks;

namespace Assignment.Service
{
    public interface IUserDetailService
    {
        Task<CommonResonseModel> GetAllUserDetails(string url);
    }
}
