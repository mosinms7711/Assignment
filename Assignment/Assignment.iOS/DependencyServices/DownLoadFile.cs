using Assignment.DependencyServices;
using System.IO;
using System.Threading.Tasks;
using UIKit;
using QuickLook;
using Xamarin.Forms;
using System;
using Assignment.iOS.DependencyServices;

[assembly: Dependency(typeof(DownLoadFile))]
namespace Assignment.iOS.DependencyServices
{
    public class DownLoadFile : IDownloadService
    {
        string pathToNewFolder = string.Empty;

        public async Task SaveFileInDownloadsAsync(string filename, MemoryStream stream)
        {
            string filePath = string.Empty;
            await Task.Run(() =>
            {
                //Get the root path in iOS device.
                if (string.IsNullOrEmpty(pathToNewFolder))
                {
                    pathToNewFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "");
                }

                filePath = Path.Combine(pathToNewFolder, filename);

                //Create a file and write the stream into it.
                FileStream fileStream = File.Open(filePath, FileMode.Create);
                stream.Position = 0;
                stream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            });

            DocumentView(filePath, filename);
        }

        private void DocumentView(string filePath, string filename)
        {
            //Invoke the saved document for viewing
            Device.BeginInvokeOnMainThread(() =>
            {
                UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                while (currentController.PresentedViewController != null)
                    currentController = currentController.PresentedViewController;

                QLPreviewController qlPreview = new QLPreviewController();
                QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
                qlPreview.DataSource = new PreviewControllerDS(item);

                currentController.PresentViewController(qlPreview, true, null);

            });
        }
    }
}