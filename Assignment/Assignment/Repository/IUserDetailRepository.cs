using Assignment.Model;
using System.IO;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public interface IUserDetailRepository
    {
        Task<CommonResonseModel> GetAllUserDetails(string url);
    }
}
