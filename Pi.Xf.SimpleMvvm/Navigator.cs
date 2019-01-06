using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pi.Xf.SimpleMvvm
{
    public sealed class Navigator
    {
        private static readonly Lazy<Navigator> _navigatorInstance = new Lazy<Navigator>(() => new Navigator());
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();

        private Navigator()
        {
        }

        public static Navigator Instance => _navigatorInstance.Value;

        /// <summary>
        /// Configure each view separately. If you follow convention and placed all views in the View folder of your project, call Configure()
        /// </summary>
        /// <param name="pageKey">Name of the page. This key will be used to navigate to the page</param>
        /// <param name="pageType">the page associated with the pageKey</param>
        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        /// <summary>
        /// Navigates to the page linked with the pagekey
        /// </summary>
        /// <param name="pageKey">name of the page you want to navigate to</param>
        /// <param name="data">data to pass to the viewmodel</param>
        /// <param name="animated">animate the navigation</param>
        /// <returns>task</returns>
        internal async Task NavigateTo(string pageKey, object data, bool animated)
        {
            Page instance;
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                    throw new InvalidOperationException($"No such Page: {pageKey}. Did you forgot to call Navigator.Instance.Configure?");

                instance = (Page)Activator.CreateInstance(_pagesByKey[pageKey]);

                if (instance.BindingContext is INavigationNotification nav)
                {
                    nav.State = data;
                }
            }
            await Application.Current.MainPage.Navigation.PushAsync(instance, animated).ConfigureAwait(false);

        }

        /// <summary>
        /// Navigates back to the previous page and calls OnNavigateBack on the ViewModel with the state of the previous page
        /// </summary>
        /// <param name="animated">animate the navigation</param>
        /// <returns>task</returns>
        internal async Task NavigateBack(object data,bool animated)
        {
            var indexOfPreviousPage = Application.Current.MainPage.Navigation.NavigationStack.Count - 2;
            if (indexOfPreviousPage >= 0)
            {
                var previousPage = Application.Current.MainPage.Navigation.NavigationStack[indexOfPreviousPage];
                if (previousPage != null && previousPage.BindingContext is INavigationNotification pnav)
                {
                    pnav.State = data;
                }
            }


            await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
        }


    }
}
