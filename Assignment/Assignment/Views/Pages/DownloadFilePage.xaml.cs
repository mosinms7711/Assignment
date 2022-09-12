using Assignment.DependencyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadFilePage : ContentPage
    {
        public DownloadFilePage()
        {
            InitializeComponent();
        }

        async Task GetFile(string fileName, Uri url)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStreamAsync();
                var memoryStream = new MemoryStream();
                result.CopyTo(memoryStream);
                await DependencyService.Get<IDownloadService>().SaveFileInDownloadsAsync(fileName, memoryStream);
            }
        }

        private async void btnDownloadPdf_Clicked(object sender, EventArgs e)
        {
            await GetFile("dummy.pdf", new Uri("https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf"));
        }

        private async void btnDownloadPng_Clicked(object sender, EventArgs e)
        {
            await GetFile("dummy.png", new Uri("https://png.pngtree.com/png-clipart/20210312/original/pngtree-simple-capsule-medicine-linear-icon-png-image_6074701.png"));
        }

        private async void btnDownloadJpg_Clicked(object sender, EventArgs e)
        {
            await GetFile("dummy.jpg", new Uri("https://aka.ms/campus.jpg"));
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}