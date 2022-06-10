using Assignment.Model;
using Assignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        private UserDeatilsPageViewModel userDetailsPageViewModel => App.GetInstance<UserDeatilsPageViewModel>();

        public UserDetailsPage(UserDetailsModel userDetailsModel)
        {
            this.BindingContext = userDetailsPageViewModel;
            this.userDetailsPageViewModel.UserDetails=userDetailsModel;
            InitializeComponent();
        }
    }
}