using Assignment.Model;
using Assignment.Navigation;
using Assignment.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assignment.ViewModel
{
    public class UserDeatilsPageViewModel: BaseViewModel
    {
        #region Private Properties
        private UserDetailsModel userDetails;
        #endregion

        #region Constructor
        public UserDeatilsPageViewModel(IPageNavigationService pageNavigation) : base(pageNavigation)
        {
            InitializeCommand();
        }
        #endregion

        #region Command
        public ICommand GoBackAsyncCommand { get; set; }
        #endregion

        #region Public Properties
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

        #region Private Methods
        void InitializeCommand()
        {
            GoBackAsyncCommand = new Command(async () => await GoBackAsync());
        }

        async Task GoBackAsync()
        {
            await pageNavigation.GoBackAsync();
        }
        #endregion
    }
}
