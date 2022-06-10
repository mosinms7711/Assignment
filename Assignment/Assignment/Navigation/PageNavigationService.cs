using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment.Navigation
{
    /// <seealso cref="Assignment.Navigation.IPageNavigationService" />
    public class PageNavigationService :IPageNavigationService
    {
        /// <summary>
        /// The instance
        /// </summary>
        static readonly Lazy<PageNavigationService> instance = new Lazy<PageNavigationService>(() => new PageNavigationService());

        /// <summary>
        /// The current page key
        /// </summary>
        private string _currentPageKey;

        /// <summary>
        /// The navigation stack
        /// </summary>
        private readonly Stack<KeyValuePair<string, Type>> _navigationStack;
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static PageNavigationService Instance => instance.Value;

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        public Dictionary<string, Type> Pages { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="PageNavigationService"/> class from being created.
        /// </summary>
        PageNavigationService()
        {
            Pages = new Dictionary<string, Type>();
            _navigationStack = new Stack<KeyValuePair<string, Type>>();            
        }

        /// <summary>
        /// Goes the back asynchronous.
        /// </summary>
        public async Task GoBackAsync()
        {
            if (MainPage.Navigation.ModalStack.Count > 0)
            {
                await MainPage.Navigation.PopModalAsync();
            }
            else
            {
                await MainPage.Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="parameters">The parameters.</param>
        public void NavigateTo(string pageKey, params object[] parameters)
        {
            try
            {
                MainPage.Navigation.PushAsync(GetPageToPush(pageKey, parameters));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the main page.
        /// </summary>
        /// <value>
        /// The main page.
        /// </value>
        public Page MainPage
        {
            get
            {
                return Application.Current.MainPage;
            }
        }

        /// <summary>
        /// Gets the page to push.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private Page GetPageToPush(string pageKey, params object[] parameters)
        {
            Page displayPage = (Page)Activator.CreateInstance(Pages[pageKey], parameters);
            _currentPageKey = pageKey;
            _navigationStack.Push(new KeyValuePair<string, Type>(pageKey, Pages[pageKey]));
            return displayPage;
        }
    }
}
