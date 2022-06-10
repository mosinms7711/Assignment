using Assignment.Common;
using Assignment.Model;
using Assignment.Navigation;
using Assignment.Repository;
using Assignment.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assignment.ViewModel
{
    public class UserMainPageViewModel : BaseViewModel
    {
        #region Private Properties
        readonly IUserDetailRepository userDetailRepository;

        int pageNumber = 1;

        bool isLastPage;

        private ObservableCollection<UserDetailsModel> usersList;

        private UserDetailsModel selecteduser;

        private readonly List<UserDetailsModel> duplicateUserList;
        #endregion

        #region Constructor
        public UserMainPageViewModel(IUserDetailRepository userDetailRepository, IPageNavigationService pageNavigation) : base(pageNavigation)
        {
            this.userDetailRepository = userDetailRepository;
            UsersList = new ObservableCollection<UserDetailsModel>();
            duplicateUserList = new List<UserDetailsModel>();
            InitializeCommand();
        }
        #endregion

        #region Command
        public ICommand InitAsyncCommand { get; set; }
        public ICommand UserSelectedCommand { get; set; }
        public ICommand LoadMoreUserAsyncCommand { get; set; }
        #endregion

        #region Public Properties
        public ObservableCollection<UserDetailsModel> UsersList
        {
            get => usersList;
            set
            {
                usersList = value;
                RaisePropertyChanged(nameof(UsersList));
            }
        }

        public UserDetailsModel Selecteduser
        {
            get => selecteduser;
            set
            {
                selecteduser = value;
                RaisePropertyChanged(nameof(Selecteduser));
            }
        }
        #endregion

        #region Private Methods
        void InitializeCommand()
        {
            InitAsyncCommand = new Command(async () => await OnInitAsync());
            UserSelectedCommand = new Command(UserSelected);
            LoadMoreUserAsyncCommand = new Command(async () => await LoadMoreUserAsync());
        }

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

        void UserSelected()
        {
            pageNavigation.NavigateTo(AppConstantsPageKeys.UserDetailsPageKey, UsersList?.FirstOrDefault(x => x.Id.Equals(Selecteduser.Id)) ?? default(UserDetailsModel));
        }

        async Task LoadMoreUserAsync()
        {
            if (!isLastPage)
            {
                await OnInitAsync();
            }
        }

        string GetUserDetailsUrl()
        {
            return $"{ServiceConstants.BaseUrl}{ServiceConstants.Page}{pageNumber}";
        }
        #endregion
    }
}
