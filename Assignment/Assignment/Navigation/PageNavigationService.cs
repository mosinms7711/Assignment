using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment.Navigation
{
    public class PageNavigationService :IPageNavigationService
    {
        static readonly Lazy<PageNavigationService> instance = new Lazy<PageNavigationService>(() => new PageNavigationService());

        private string _currentPageKey;

        private readonly Stack<KeyValuePair<string, Type>> _navigationStack;
        public static PageNavigationService Instance => instance.Value;

        public Dictionary<string, Type> Pages { get; set; }

        PageNavigationService()
        {
            Pages = new Dictionary<string, Type>();
            _navigationStack = new Stack<KeyValuePair<string, Type>>();            
        }

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

        public Page MainPage
        {
            get
            {
                return Application.Current.MainPage;
            }
        }

        private Page GetPageToPush(string pageKey, params object[] parameters)
        {
            Page displayPage = (Page)Activator.CreateInstance(Pages[pageKey], parameters);
            _currentPageKey = pageKey;
            _navigationStack.Push(new KeyValuePair<string, Type>(pageKey, Pages[pageKey]));
            return displayPage;
        }
    }
}
