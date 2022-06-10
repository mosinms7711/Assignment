using Assignment.Model;
using Assignment.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.Views.Pages
{
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        /// <summary>
        /// Gets the user details page view model.
        /// </summary>
        /// <value>
        /// The user details page view model.
        /// </value>
        private UserDeatilsPageViewModel userDetailsPageViewModel => App.GetInstance<UserDeatilsPageViewModel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailsPage"/> class.
        /// </summary>
        /// <param name="userDetailsModel">The user details model.</param>
        public UserDetailsPage(UserDetailsModel userDetailsModel)
        {
            this.BindingContext = userDetailsPageViewModel;
            this.userDetailsPageViewModel.UserDetails=userDetailsModel;
            InitializeComponent();
        }
    }
}