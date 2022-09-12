using QuickLook;
using System;

namespace Assignment.iOS.DependencyServices
{
    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        private readonly QLPreviewItem _item;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewControllerDS"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public PreviewControllerDS(QLPreviewItem item)
        {
            _item = item;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="controller">To be added.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="controller">To be added.</param>
        /// <param name="index">To be added.</param>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return _item;
        }
    }
}