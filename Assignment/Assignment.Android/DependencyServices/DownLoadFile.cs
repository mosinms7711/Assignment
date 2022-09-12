using Android.App;
using Android.Content;
using Android.OS;
using Assignment.DependencyServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Android;
using Android.Content.PM;
using Android.Webkit;
using Java.IO;
using AndroidX.Core.Content;
using AndroidX.Core.App;
using Xamarin.Forms;
using Assignment.Droid.DependencyServices;
using Environment = System.Environment;

[assembly: Dependency(typeof(DownLoadFile))]
namespace Assignment.Droid.DependencyServices
{
    public class DownLoadFile: IDownloadService
    {
        public async Task SaveFileInDownloadsAsync(string filename, MemoryStream stream)
        {
            await Task.Run(() =>
            {

                if (ContextCompat.CheckSelfPermission(Android.App.Application.Context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                {
                    ActivityCompat.RequestPermissions((Activity)Android.App.Application.Context, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
                }


                string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                Java.IO.File myDir = new Java.IO.File(Path.Combine(root, "DownloadedFiles"));
                myDir.Mkdir();

                Java.IO.File file = new Java.IO.File(myDir, filename);

                if (file.Exists()) file.Delete();



                try
                {
                    FileOutputStream outs = new FileOutputStream(file);
                    outs.Write(stream.ToArray());

                    outs.Flush();
                    outs.Close();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }

                if (file.Exists())
                {
                    string extension = MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                    string mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                    Android.Net.Uri path = FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".fileprovider", file);
                    intent.SetDataAndType(path, mimeType);
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    Android.App.Application.Context.StartActivity(intent);
                }
            });
        }
    }
}