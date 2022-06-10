using Assignment.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment.Views
{
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMainPage : ContentPage
    {
        /// <summary>
        /// Gets the user main page view model.
        /// </summary>
        /// <value>
        /// The user main page view model.
        /// </value>
        private UserMainPageViewModel userMainPageViewModel => App.GetInstance<UserMainPageViewModel>();
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMainPage"/> class.
        /// </summary>
        public UserMainPage()
        {
            this.BindingContext = userMainPageViewModel;
            userMainPageViewModel?.InitAsyncCommand?.Execute(this);
            InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            userMainPageViewModel?.LoadAppCounterAsyncCommand?.Execute(this);
        }
    }
}