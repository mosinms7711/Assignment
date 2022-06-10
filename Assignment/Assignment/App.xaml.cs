using Assignment.Common;
using Assignment.Views;
using Assignment.Views.Pages;
using GalaSoft.MvvmLight.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BootStrapper.Instance.Initialize();
            MainPage = new NavigationPage(new UserMainPage());
        }


        /// <summary>
        /// Get registerd ViewModel instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>() where T : class
        {
            if (!SimpleIoc.Default.IsRegistered<T>())
            {
                SimpleIoc.Default.Register<T>();
            }

            return SimpleIoc.Default.GetInstance<T>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
