using Assignment.Common;
using Assignment.Model;
using Assignment.Navigation;
using Assignment.Repository;
using Assignment.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assignment.ViewModel
{
    /// <seealso cref="Assignment.ViewModel.Common.BaseViewModel" />
    public class UserMainPageViewModel : BaseViewModel
    {
        #region Private Properties
        /// <summary>
        /// The user detail repository
        /// </summary>
        readonly IUserDetailRepository userDetailRepository;

        /// <summary>
        /// The page number
        /// </summary>
        int pageNumber = 1;

        /// <summary>
        /// The is last page
        /// </summary>
        bool isLastPage;

        /// <summary>
        /// The users list
        /// </summary>
        private ObservableCollection<UserDetailsModel> usersList;

        /// <summary>
        /// The selecteduser
        /// </summary>
        private UserDetailsModel selecteduser;

        /// <summary>
        /// The duplicate user list
        /// </summary>
        private readonly List<UserDetailsModel> duplicateUserList;

        /// <summary>
        /// The application count
        /// </summary>
        private string appCount;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMainPageViewModel"/> class.
        /// </summary>
        /// <param name="userDetailRepository">The user detail repository.</param>
        /// <param name="pageNavigation">The page navigation.</param>
        public UserMainPageViewModel(IUserDetailRepository userDetailRepository, IPageNavigationService pageNavigation) : base(pageNavigation)
        {
            this.userDetailRepository = userDetailRepository;
            UsersList = new ObservableCollection<UserDetailsModel>();
            duplicateUserList = new List<UserDetailsModel>();
            InitializeCommand();
        }
        #endregion

        #region Command
        /// <summary>
        /// Gets or sets the initialize asynchronous command.
        /// </summary>
        /// <value>
        /// The initialize asynchronous command.
        /// </value>
        public ICommand InitAsyncCommand { get; set; }
        /// <summary>
        /// Gets or sets the user selected command.
        /// </summary>
        /// <value>
        /// The user selected command.
        /// </value>
        public ICommand UserSelectedCommand { get; set; }
        /// <summary>
        /// Gets or sets the load more user asynchronous command.
        /// </summary>
        /// <value>
        /// The load more user asynchronous command.
        /// </value>
        public ICommand LoadMoreUserAsyncCommand { get; set; }
        /// <summary>
        /// Gets or sets the load application counter asynchronous command.
        /// </summary>
        /// <value>
        /// The load application counter asynchronous command.
        /// </value>
        public ICommand LoadAppCounterAsyncCommand { get; set; }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the users list.
        /// </summary>
        /// <value>
        /// The users list.
        /// </value>
        public ObservableCollection<UserDetailsModel> UsersList
        {
            get => usersList;
            set
            {
                usersList = value;
                RaisePropertyChanged(nameof(UsersList));
            }
        }

        /// <summary>
        /// Gets or sets the selecteduser.
        /// </summary>
        /// <value>
        /// The selecteduser.
        /// </value>
        public UserDetailsModel Selecteduser
        {
            get => selecteduser;
            set
            {
                selecteduser = value;
                RaisePropertyChanged(nameof(Selecteduser));
            }
        }

        /// <summary>
        /// Gets or sets the application count.
        /// </summary>
        /// <value>
        /// The application count.
        /// </value>
        public string AppCount
        {
            get => appCount;
            set
            {
                appCount = value;
                RaisePropertyChanged(nameof(AppCount));
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initializes the command.
        /// </summary>
        void InitializeCommand()
        {
            InitAsyncCommand = new Command(async () => await OnInitAsync());
            UserSelectedCommand = new Command(UserSelected);
            LoadMoreUserAsyncCommand = new Command(async () => await LoadMoreUserAsync());
            LoadAppCounterAsyncCommand = new Command(async () => await LoadAppCounterAsync());
        }

        /// <summary>
        /// Called when [initialize asynchronous].
        /// </summary>
        async Task OnInitAsync()
        {
            var result = await userDetailRepository.GetAllUserDetails(GetUserDetailsUrl());

            if ((result?.UserDetailsModelList?.Any() ?? false) && !isLastPage)
            {
                duplicateUserList.AddRange(result?.UserDetailsModelList);
                UsersList = new ObservableCollection<UserDetailsModel>(duplicateUserList);
                isLastPage = result.TotalPages == pageNumber;
                pageNumber += 1;
            }
        }

        /// <summary>
        /// Users the selected.
        /// </summary>
        void UserSelected()
        {
            pageNavigation.NavigateTo(AppConstantsPageKeys.UserDetailsPageKey, UsersList?.FirstOrDefault(x => x.Id.Equals(Selecteduser.Id)) ?? default(UserDetailsModel));
        }

        /// <summary>
        /// Loads the more user asynchronous.
        /// </summary>
        async Task LoadMoreUserAsync()
        {
            if (!isLastPage)
            {
                await OnInitAsync();
            }
        }

        /// <summary>
        /// Gets the user details URL.
        /// </summary>
        /// <returns></returns>
        string GetUserDetailsUrl()
        {
            return $"{ServiceConstants.BaseUrl}{ServiceConstants.Page}{pageNumber}";
        }

        /// <summary>
        /// Loads the application counter asynchronous.
        /// </summary>
        async Task LoadAppCounterAsync()
        {
            var count = await SecureStorage.GetAsync("SessionCount");

            if (string.IsNullOrEmpty(count))
            {
                await SecureStorage.SetAsync("SessionCount", $"{1}");
            }
            else
            {
                AppCount = $"{Convert.ToInt32(count) + 1}";
                await SecureStorage.SetAsync("SessionCount", $"{AppCount}");
            }
        }
        #endregion
    }
}
