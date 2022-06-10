using Assignment.Navigation;
using Assignment.Repository;
using Assignment.Service;
using Assignment.ViewModel;
using Assignment.Views;
using Assignment.Views.Pages;
using GalaSoft.MvvmLight.Ioc;
using System;
using Xamarin.Forms;

namespace Assignment.Common
{
    public class BootStrapper
    {
        /// <summary>
        /// The navigation service
        /// </summary>
        IPageNavigationService navigationService;

        /// <summary>
        /// The lazy
        /// </summary>
        private static readonly Lazy<BootStrapper> lazy = new Lazy<BootStrapper>(() => new BootStrapper());

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static BootStrapper Instance { get { return lazy.Value; } }

        /// <summary>
        /// Prevents a default instance of the <see cref="BootStrapper"/> class from being created.
        /// </summary>
        private BootStrapper() { }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            RegisterRepositories(SimpleIoc.Default);
            RegisterServices(SimpleIoc.Default);
            RegisterViewModels();
            RegisterPageKeys();
        }

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="container">The container.</param>
        void RegisterRepositories(SimpleIoc container)
        {
            if (container is null) return;

            RegisterInterface<IUserDetailRepository, UserDetailRepository>(container);
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="container">The container.</param>
        void RegisterServices(SimpleIoc container)
        {
            if (container is null) return;

            if (!container.IsRegistered<IPageNavigationService>())
                container.Register<IPageNavigationService>(() => PageNavigationService.Instance);

            RegisterInterface<IPageNavigationService, PageNavigationService>(container);
            RegisterInterface<IUserDetailService, UserDetailService>(container);

        }

        /// <summary>
        /// Registers the page keys.
        /// </summary>
        private void RegisterPageKeys()
        {
            navigationService = SimpleIoc.Default.GetInstance<IPageNavigationService>();

            RegisterPageKeys<UserDetailsPage>(AppConstantsPageKeys.UserDetailsPageKey);
            RegisterPageKeys<UserMainPage>(AppConstantsPageKeys.UserMainPageKey);
        }

        /// <summary>
        /// Registers the view models.
        /// </summary>
        void RegisterViewModels()
        {
            RegisterViewModel<UserDeatilsPageViewModel>();
            RegisterViewModel<UserMainPageViewModel>();
        }

        /// <summary>
        /// Registers the interface.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImpementation">The type of the impementation.</typeparam>
        /// <param name="container">The container.</param>
        protected void RegisterInterface<TInterface, TImpementation>(SimpleIoc container) where TInterface : class where TImpementation : class, TInterface
        {
            if (!container.IsRegistered<TInterface>())
            {
                container.Register<TInterface, TImpementation>();
            }
        }

        /// <summary>
        /// Registers the page keys.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageKey">The page key.</param>
        void RegisterPageKeys<T>(string pageKey) where T : Page
        {
            if (!navigationService.Pages.ContainsKey(pageKey))
            {
                navigationService.Pages.Add(pageKey, typeof(T));
            }
        }

        /// <summary>
        /// Registers the view model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RegisterViewModel<T>() where T : class
        {
            if (!SimpleIoc.Default.IsRegistered<T>())
            {
                SimpleIoc.Default.Register<T>();
            }
        }
    }
}
