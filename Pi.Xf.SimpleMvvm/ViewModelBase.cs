using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Xf.SimpleMvvm
{
    public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged, INavigationNotification
    {
        private Navigator _navigator = Navigator.Instance;

        public object State { get; set; }

        public virtual Task OnNavigatedFrom(object param)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatingTo()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnNavigatedBack(object param)
        {
            return Task.CompletedTask;
        }
        

        /// <summary>
        /// Navigates to the page linked with the pagekey
        /// </summary>
        /// <param name="pageKey">name of the page you want to navigate to</param>
        /// <returns>task</returns>
        protected async Task NavigateTo(string pageKey)
        {
            await NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Navigates to the page linked with the pagekey
        /// </summary>
        /// <param name="pageKey">name of the page you want to navigate to</param>
        /// <param name="data">data to pass to the viewmodel</param>
        /// <returns>task</returns>
        protected async Task NavigateTo(string pageKey, object data)
        {

            await NavigateTo(pageKey, data, animated: false);
        }

        /// <summary>
        /// Navigates to the page linked with the pagekey
        /// </summary>
        /// <param name="pageKey">name of the page you want to navigate to</param>
        /// <param name="data">data to pass to the viewmodel</param>
        /// <param name="animated">animate the navigation</param>
        /// <returns>task</returns>
        protected async Task NavigateTo(string pageKey, object data, bool animated)
        {
            await _navigator.NavigateTo(pageKey, data, animated).ConfigureAwait(false);

        }

        /// <summary>
        /// Navigate back to the previous page
        /// </summary>
        /// <returns>task</returns>
        protected async Task NavigateBack()
        {
            await NavigateBack(null);
        }

        /// <summary>
        /// Navigates back to the previous page with option for animation
        /// </summary>
        /// <param name="data">data to return to previous page</param>
        /// <returns>task</returns>
        protected async Task NavigateBack(object data)
        {
            await NavigateBack(data, false);
        }

        /// <summary>
        /// Navigates back to the previous page with data and option for animation
        /// </summary>
        /// <param name="animated">animate the navigation</param>
        /// <param name="data">data to return to previous page</param>
        /// <returns>task</returns>
        protected async Task NavigateBack(object data,bool animated)
        {
            await _navigator.NavigateBack(data,animated).ConfigureAwait(false);
        }


    }
}
