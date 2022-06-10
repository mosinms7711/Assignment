using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Navigation
{
    public interface IPageNavigationService
    {
        Dictionary<string, Type> Pages { get; set; }

        void NavigateTo(string pageKey, params object[] parameters);

        Task GoBackAsync();
    }
}
