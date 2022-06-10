using Assignment.Navigation;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ViewModel.Common
{
    public class BaseViewModel :ViewModelBase
    {
        protected readonly IPageNavigationService pageNavigation;

        public BaseViewModel(IPageNavigationService pageNavigation)
        {
            this.pageNavigation = pageNavigation;
        }
    }
}
