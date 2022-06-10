using Assignment.Navigation;
using GalaSoft.MvvmLight;

namespace Assignment.ViewModel.Common
{
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class BaseViewModel :ViewModelBase
    {
        /// <summary>
        /// The page navigation
        /// </summary>
        protected readonly IPageNavigationService pageNavigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="pageNavigation">The page navigation.</param>
        public BaseViewModel(IPageNavigationService pageNavigation)
        {
            this.pageNavigation = pageNavigation;
        }
    }
}
