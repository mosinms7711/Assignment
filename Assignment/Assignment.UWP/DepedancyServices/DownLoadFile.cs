using Assignment.DependencyServices;
using Assignment.UWP.DepedancyServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(DownLoadFile))]
namespace Assignment.UWP.DepedancyServices
{
    internal class DownLoadFile : IDownloadService
    {
        public async Task SaveFileInDownloadsAsync(string filename, MemoryStream stream)
        {
            try
            {

                if (filename == null)
                    return;

                //save the stream into the Downloads Folder. 
                StorageFile outFile = await DownloadsFolder.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);


                using (Stream outStream = await outFile.OpenStreamForWriteAsync())
                {
                    outStream.Write(stream.ToArray(), 0, (int)stream.Length);
                }

                await Windows.System.Launcher.LaunchFileAsync(outFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
