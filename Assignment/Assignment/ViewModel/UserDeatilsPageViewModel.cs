using Assignment.Model;
using Assignment.Navigation;
using Assignment.ViewModel.Common;

namespace Assignment.ViewModel
{
    /// <seealso cref="Assignment.ViewModel.Common.BaseViewModel" />
    public class UserDeatilsPageViewModel: BaseViewModel
    {
        #region Private Properties
        /// <summary>
        /// The user details
        /// </summary>
        private UserDetailsModel userDetails;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDeatilsPageViewModel"/> class.
        /// </summary>
        /// <param name="pageNavigation">The page navigation.</param>
        public UserDeatilsPageViewModel(IPageNavigationService pageNavigation) : base(pageNavigation)
        {

        }
        #endregion


        #region Public Properties
        /// <summary>
        /// Gets or sets the user details.
        /// </summary>
        /// <value>
        /// The user details.
        /// </value>
        public UserDetailsModel UserDetails
        {
            get => userDetails;
            set
            {
                userDetails = value;
                RaisePropertyChanged(nameof(UserDetails));
            }
        }
        #endregion
    }
}
