using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Navigation
{
    public interface IPageNavigationService
    {
        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        Dictionary<string, Type> Pages { get; set; }

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="parameters">The parameters.</param>
        void NavigateTo(string pageKey, params object[] parameters);

        /// <summary>
        /// Goes the back asynchronous.
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
