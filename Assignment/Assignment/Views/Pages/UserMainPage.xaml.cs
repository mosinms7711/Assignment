using Assignment.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPage : ContentPage
    {
        private UserMainPageViewModel userMainPageViewModel => App.GetInstance<UserMainPageViewModel>();
        public UserMainPage()
        {
            this.BindingContext = userMainPageViewModel;
            userMainPageViewModel?.InitAsyncCommand?.Execute(this);
            InitializeComponent();
        }
    }
}