using Foundation;
using QuickLook;
using System.IO;

namespace Assignment.iOS.DependencyServices
{
    public class QLPreviewItemBundle : QLPreviewItem
    {
        private readonly string _fileName;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="QLPreviewItemBundle"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="filePath">The file path.</param>
        public QLPreviewItemBundle(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }

        /// <summary>
        /// NSUrl
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override NSUrl ItemUrl
        {
            get
            {
                var documents = NSBundle.MainBundle.BundlePath;
                var lib = Path.Combine(documents, _filePath);
                var url = NSUrl.FromFilename(lib);
                return url;
            }
        }
    }
}