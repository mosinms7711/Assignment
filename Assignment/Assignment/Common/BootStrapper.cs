using Assignment.Navigation;
using Assignment.Repository;
using Assignment.Service;
using Assignment.Service.Common;
using Assignment.ViewModel;
using Assignment.Views;
using Assignment.Views.Pages;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Assignment.Common
{
    public class BootStrapper
    {
        IPageNavigationService navigationService;

        private static readonly Lazy<BootStrapper> lazy = new Lazy<BootStrapper>(() => new BootStrapper());

        public static BootStrapper Instance { get { return lazy.Value; } }

        private BootStrapper() { }

        public void Initialize()
        {
            RegisterRepositories(SimpleIoc.Default);
            RegisterServices(SimpleIoc.Default);
            RegisterViewModels();
            RegisterPageKeys();
        }

        void RegisterRepositories(SimpleIoc container)
        {
            if (container is null) return;

            RegisterInterface<IUserDetailRepository, UserDetailRepository>(container);
        }

        void RegisterServices(SimpleIoc container)
        {
            if (container is null) return;

            if (!container.IsRegistered<IPageNavigationService>())
                container.Register<IPageNavigationService>(() => PageNavigationService.Instance);

            RegisterInterface<IPageNavigationService, PageNavigationService>(container);
            RegisterInterface<IUserDetailService, UserDetailService>(container);

        }

        private void RegisterPageKeys()
        {
            navigationService = SimpleIoc.Default.GetInstance<IPageNavigationService>();

            RegisterPageKeys<UserDetailsPage>(AppConstantsPageKeys.UserDetailsPageKey);
            RegisterPageKeys<UserMainPage>(AppConstantsPageKeys.UserMainPageKey);
        }

        void RegisterViewModels()
        {
            RegisterViewModel<UserDeatilsPageViewModel>();
            RegisterViewModel<UserMainPageViewModel>();
        }

        protected void RegisterInterface<TInterface, TImpementation>(SimpleIoc container) where TInterface : class where TImpementation : class, TInterface
        {
            if (!container.IsRegistered<TInterface>())
            {
                container.Register<TInterface, TImpementation>();
            }
        }

        void RegisterPageKeys<T>(string pageKey) where T : Page
        {
            if (!navigationService.Pages.ContainsKey(pageKey))
            {
                navigationService.Pages.Add(pageKey, typeof(T));
            }
        }

        void RegisterViewModel<T>() where T : class
        {
            if (!SimpleIoc.Default.IsRegistered<T>())
            {
                SimpleIoc.Default.Register<T>();
            }
        }
    }
}
