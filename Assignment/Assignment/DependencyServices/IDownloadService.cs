using System.IO;
using System.Threading.Tasks;

namespace Assignment.DependencyServices
{
    public interface IDownloadService
    {
        /// <summary>
        /// Saves to Downloads Folder
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        Task SaveFileInDownloadsAsync(string filename, MemoryStream stream);

    }
}
